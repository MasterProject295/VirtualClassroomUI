using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Leap.Unity.Interaction;

public class DisableComponentCup : NetworkBehaviour {

	private Rigidbody rb;
	private BoxCollider boxCollider;
	private InteractionBehaviour ib;
	// Use this for initialization
	void Start () {
		
		if (isClient)
		{
			Debug.Log("Disabling Components: Cup");
			rb = GetComponent<Rigidbody>();
			rb.detectCollisions = false;
			rb.useGravity = false;
			ib = GetComponent<InteractionBehaviour>();
			ib.enabled = false;
			boxCollider = GetComponentInChildren<BoxCollider>();	
			boxCollider.enabled = false;
			Destroy (boxCollider);
			Destroy (ib);
			Destroy(rb);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
