using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraManager : NetworkBehaviour {

	// Use this for initialization
	void Start () {

		if (isLocalPlayer) {
			Debug.Log ("****I am Student***");
			//Camera.main.gameObject.SetActive (false);
			//GetComponent<Camera> ().enabled = true;
			transform.position = new Vector3 (0f, 1.5f, 2.1f);
			transform.rotation = Quaternion.Euler (0, -180 , 0);
			Debug.Log (Camera.main.transform.rotation.x + " " + Camera.main.transform.rotation.y + " " + Camera.main.transform.rotation.z);
			Camera.main.transform.position = transform.position;
			Camera.main.transform.rotation = transform.rotation;
			Debug.Log (Camera.main.transform.rotation.x + " " + Camera.main.transform.rotation.y + " " + Camera.main.transform.rotation.z);
			//Camera.main.gameObject.SetActive(false);
		}


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
