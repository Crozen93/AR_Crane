using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private void Update()
    {
        //is the player touching the screen
        //create a raycast from the screen to the touch
        //did we hit anything?
        //if we did, was it a button?
        //if so, trigger the button event

        //player touch screen
        //Mobile touch
        if (Input.touchCount > 0)
        {
            //create raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //did we hit anything?
                if (hit.collider != null)
                {
                    //was it button?
                    if (hit.collider.gameObject.GetComponent<DashBoardButton>())
                    {
                        hit.collider.gameObject.GetComponent<DashBoardButton>().onHold.Invoke();
                    }
                }
            }
        }

        //Test in Windows
        //Windows touch
        if (Input.GetMouseButton(0))
        {
            //create raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //did we hit anything?
                if (hit.collider != null)
                {
                    //was it button?
                    if (hit.collider.gameObject.GetComponent<DashBoardButton>())
                    {
                        hit.collider.gameObject.GetComponent<DashBoardButton>().onHold.Invoke();
                    }
                }
            }
        }
    }
}
