using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class InstructorView : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if (isClient) {
			Debug.Log ("Initializing Student View");	
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 100), (int)(1.0f / Time.smoothDeltaTime) + " ");
	}
}
