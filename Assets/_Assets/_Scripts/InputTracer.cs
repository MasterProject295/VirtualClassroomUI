using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class InputTracer : NetworkBehaviour {

	public GameObject inputReader;

	// Use this for initialization
	void Start () {
		inputReader = Instantiate (inputReader);
		NetworkServer.Spawn (inputReader);
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer) {
			Debug.Log ("I am server");
			foreach (KeyCode kCode in Enum.GetValues(typeof(KeyCode))) {
				if (Input.GetKeyDown (kCode)) {
					int keyCode = (int)kCode;
					//GameObject inputReaderGO = GameObject.FindGameObjectWithTag ("inputreader");
					Debug.Log ("Notifying Input Reader");
					inputReader.GetComponent<InputReader> ().RpcInputReceived (keyCode);
				}
			}
		}		
	}
}
