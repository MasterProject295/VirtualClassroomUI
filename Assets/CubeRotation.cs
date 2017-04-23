using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class CubeRotation : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocalPlayer) {
			Debug.Log ("I am not local Player");
			//return;
		}
		if (isServer) {
			Debug.Log ("is server");

			var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

			transform.Rotate(0, x, 0);
			transform.Translate(0, 0, z);	
			//return;
		}
		if (isClient) {
			Debug.Log ("is client");
			//return;
		}
		if (hasAuthority) {
			Debug.Log ("Has Authority");
			//return;
		}

		//Debug.Log ("I am server");

			
	}
}
