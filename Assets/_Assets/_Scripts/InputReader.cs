using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InputReader : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
	}

	[ClientRpc]
	public void RpcInputReceived(int keyCode)	{
		Debug.Log ("Profesor Typed: " + (KeyCode)keyCode);
	}
}
