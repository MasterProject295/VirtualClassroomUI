using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DisableAnimator : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
		if (!isServer) {
			gameObject.GetComponent<Animator> ().enabled = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
