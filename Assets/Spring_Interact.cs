using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Spring_Interact : MonoBehaviour
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
            SpringJoint joint = GetComponent<SpringJoint>();
            joint.connectedBody = item.GetComponent<Rigidbody>();
            holding = true;
        }

       // else if (holding && SteamVR_Input.GetStateUp("GrabPinch", SteamVR_Input_Sources.Any))
      //  {
       //     GameObject item = other.gameObject;
       //     SpringJoint joint = GetComponent<SpringJoint>();
       //     joint.connectedBody = null;
        //    holding = false;
       // }
    }
}
