using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Object_Interact : MonoBehaviour
{
    public bool holding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (!holding && SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.Any))
        {
            GameObject item = other.gameObject;
            item.transform.parent = transform;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            holding = true;

          
        }

        else if (holding && SteamVR_Input.GetStateUp("GrabPinch", SteamVR_Input_Sources.Any))
        {
            GameObject item = other.gameObject;
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().useGravity = true;
            holding = false;

            Hand h = GetComponent<Hand>();
            Rigidbody toThrow = item.GetComponent<Rigidbody>();
            toThrow.velocity = h.trackedObject.GetVelocity();
            toThrow.angularVelocity = h.trackedObject.GetAngularVelocity();
        }
    }
}
