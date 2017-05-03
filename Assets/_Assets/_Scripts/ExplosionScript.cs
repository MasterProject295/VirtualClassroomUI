using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExplosionScript : NetworkBehaviour {

	GvrAudioSource gvraudiosource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[ClientRpc]
	void RpcPlayExploisonSound()	{
		Debug.Log ("Inside Rpc Play Sound");
		gvraudiosource = gameObject.GetComponent<GvrAudioSource>();
		if (!gvraudiosource.isPlaying)
		{
			Debug.Log ("Playing the sound");
			gvraudiosource.Play();
		}
	}

	[ClientRpc]
	void RpcStopExplosionSound()	{
		Debug.Log ("Inside Rpc Stop Sound");
		gvraudiosource = gameObject.GetComponent<GvrAudioSource>();
		if (gvraudiosource.isPlaying)
		{
			Debug.Log ("Stopping sound");
			gvraudiosource.Stop();
		}
	}

	public void PlayExplosionSound()	{
		if (!isServer)
			return;
		gvraudiosource = gameObject.GetComponent<GvrAudioSource>();
		if (!gvraudiosource.isPlaying)
		{
			Debug.Log ("Playing explosion sound");
			gvraudiosource.Play();
		}

		Debug.Log ("Rpc Playing Sound");
		RpcPlayExploisonSound ();
	}

	public void StopExplosionSound()	{
		if (!isServer)
			return;

		gvraudiosource = gameObject.GetComponent<GvrAudioSource>();
		if (gvraudiosource.isPlaying)
		{
			Debug.Log ("Playing explosion sound");
			gvraudiosource.Stop();
		}
		
		Debug.Log ("Rpc Stopping Sound");
		RpcStopExplosionSound ();
	}


}
