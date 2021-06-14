using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject hookConnectionPosition;

    private void Update()
    {
        //hook connection folow
        Vector3 newPos = hookConnectionPosition.transform.localPosition;
        newPos.x = transform.localPosition.x;
        hookConnectionPosition.transform.localPosition = newPos;

        //connecting line renderer from conection position to hook
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hookConnectionPosition.transform.position);
    }
}
