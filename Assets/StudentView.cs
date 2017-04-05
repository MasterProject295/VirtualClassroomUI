using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StudentView : NetworkBehaviour {

	// Use this for initialization
	void Start () {	
		if (isServer) {
			Debug.Log ("Initializing Instructor View");	
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
