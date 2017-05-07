using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Leap.Unity.Interaction;
/*
Created By: Akshay Mathur
Purpose: Disable and Remove Cube Components
Reason: GROOV-46
*/
public class DisableComponentsCube : NetworkBehaviour {

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private InteractionBehaviour ib;
    // Use this for initialization
    void Start () {

        if (isClient)
        {
			//Get References to Rigid Body, Interaction behaviour, Box Collider
            Debug.Log("Disabling Components: Cube");
            rb = GetComponent<Rigidbody>();
			//remove collision detection and gravity
            rb.detectCollisions = false;
            rb.useGravity = false;
            boxCollider = GetComponent<BoxCollider>();
			//disable boxcollider
			boxCollider.enabled = false;
            ib = GetComponent<InteractionBehaviour>();
			//disable Interaction behaviour
            ib.enabled = false;
			//Remove the components
			Destroy (boxCollider);
			Destroy (ib);
			Destroy(rb);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
