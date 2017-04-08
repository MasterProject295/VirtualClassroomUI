using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour {

	Vector3 originalPosition;
	Quaternion originalRotation;
	Vector3 originalScale;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		originalScale = transform.localScale;
	}

	private void Reset()	{
		transform.position = originalPosition;
		transform.rotation = originalRotation;
		transform.localScale = originalScale;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			Debug.Log ("User pressed R");
			Reset ();
		}
	}
}
