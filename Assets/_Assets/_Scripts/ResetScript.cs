using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour {

	private Vector3 originalPosition;
	private Quaternion originalRotation;
	private Vector3 originalScale;

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
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey (KeyCode.R)) {
			Debug.Log ("User pressed Cltr + R");
			Reset ();
		}
	}
}
