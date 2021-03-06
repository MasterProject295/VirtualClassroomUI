﻿using System.Collections;
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

		if (isClient && !isLocalPlayer) {
			Debug.Log ("Initializing Instructor View");	
			gameObject.SetActive(false);
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 100), (int)(1.0f / Time.smoothDeltaTime) + " ");
	}
}
