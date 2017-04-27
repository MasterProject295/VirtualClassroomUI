using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FireFlamesScript : NetworkBehaviour {

	GvrAudioSource gvrAudio;
	bool metalDetected = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	[ClientRpc]
	void RpcPlaySound()	{
		Debug.Log ("Inside Rpc Play Sound");
		gvrAudio = gameObject.GetComponent<GvrAudioSource>();
		if (!gvrAudio.isPlaying)
		{
			Debug.Log ("Playing the sound");
			gvrAudio.Play();
		}
	}

	[ClientRpc]
	void RpcStopSound()	{
		Debug.Log ("Inside Rpc Stop Sound");
		gvrAudio = gameObject.GetComponent<GvrAudioSource>();
		if (gvrAudio.isPlaying)
		{
			Debug.Log ("Stopping sound");
			gvrAudio.Stop();
		}
	}

	public void PlaySound()	{
		if (!isServer)
			return;

		Debug.Log ("Rpc Playing Sound");
		RpcPlaySound ();
	}

	public void StopSound()	{
		if (!isServer)
			return;

		Debug.Log ("Rpc Stopping Sound");
		RpcStopSound ();
	}
		
	public void OnTriggerEnter(Collider other)	{
		Debug.Log ("Fire Collision detected");
		if (other.CompareTag ("metal")) {
			Debug.Log ("Fire Collided with metal");
			GameObject burnerTouchPoint = GameObject.FindGameObjectWithTag ("touchpoint");
			burnerTouchPoint.GetComponent<FireController> ().StartSmoke ();
		} else if(other.CompareTag ("tube")){
			Debug.Log ("Fire Collided with tube");
			GameObject burnerTouchPoint = GameObject.FindGameObjectWithTag ("touchpoint");
			burnerTouchPoint.GetComponent<FireController> ().StartExplosion ();
		}
	}
		
}
