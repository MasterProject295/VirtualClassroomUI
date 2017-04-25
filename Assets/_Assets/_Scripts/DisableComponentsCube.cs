﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Leap.Unity.Interaction;

public class DisableComponentsCube : NetworkBehaviour {

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private InteractionBehaviour ib;
    // Use this for initialization
    void Start () {

        if (isClient)
        {
            Debug.Log("Disabling Components: Cube");
            rb = GetComponent<Rigidbody>();
            rb.detectCollisions = false;
            rb.useGravity = false;
            Destroy(rb);
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            ib = GetComponent<InteractionBehaviour>();
            ib.enabled = false;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
