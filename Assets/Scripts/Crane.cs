using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    //speeds
    public float turnSpeed;
    public float hooVerticalSpeed;
    public float hooHorizontalSpeed;

    //hook limits
    public float hookRaiseLimit;        //max height
    public float hookLowerLimit;        //min height
    public float hookForwardLimit;      //max forward
    public float hookBackForwardLimit;  //min forward

    //components
    public GameObject craneTop;
    public GameObject hook;

    private void Update()
    {
        // keyboard controls
        if (Input.GetKey(KeyCode.E))
            Turn(1);
        if (Input.GetKey(KeyCode.Q))
            Turn(-1);
        if (Input.GetKey(KeyCode.W))
            HookVertical(1);
        if (Input.GetKey(KeyCode.S))
            HookVertical(-1);
        if (Input.GetKey(KeyCode.D))
            HookHorizontal(1);
        if (Input.GetKey(KeyCode.A))
            HookHorizontal(-1);
    }

    //turn function - rotate crane Y axis
    public void Turn(int dir)
    {
        craneTop.transform.Rotate(Vector3.up, dir * turnSpeed * Time.deltaTime);
    }

    //move the hook - horizontal
    public void HookHorizontal(int dir)
    {
        MoveHook(new Vector2(dir, 0));
    }

    //move the hook - vertical
    public void HookVertical(int dir)
    {
        MoveHook(new Vector2(0, dir));
    }

    //main hook movement
    void MoveHook(Vector2 dir)
    {
        hook.transform.localPosition += new Vector3(dir.x * hooHorizontalSpeed, dir.y * hooVerticalSpeed, 0);

        //clamp hook position
        Vector3 clampedPos = hook.transform.localPosition;

        clampedPos.x = Mathf.Clamp(clampedPos.x, hookForwardLimit, hookBackForwardLimit);
        clampedPos.y = Mathf.Clamp(clampedPos.y, hookLowerLimit, hookRaiseLimit);

        hook.transform.localPosition = clampedPos;
    }
}
