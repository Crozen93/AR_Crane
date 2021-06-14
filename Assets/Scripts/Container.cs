using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject hookObject;
    public GameObject truckObject;

    private bool inTruck = false; // is the container in truck?

    private void OnTriggerEnter(Collider other)
    {
        //if in the truck dont do anything
        if (inTruck)
            return;

        // did hook hit us?
        if (other.gameObject == hookObject)
        {
            //attach the hook
            transform.position = hookObject.transform.Find("ContainerPos").position;
            transform.parent = other.transform;
        }
        else if (other.gameObject == truckObject)
        {
            //attach the truck
            transform.position = truckObject.transform.Find("ContainerPos").position;
            transform.rotation = other.transform.rotation;
            transform.parent = other.transform;
        }
    }
}
