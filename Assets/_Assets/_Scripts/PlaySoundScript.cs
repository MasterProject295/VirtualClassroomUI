using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlaySoundScript : NetworkBehaviour {

	GvrAudioSource gvrAudio;

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


	[ClientRpc]
	void RpcStartFire()	{
		Debug.Log ("Rpc Starting Sound");

		if (!gameObject.GetComponent<ParticleSystem> ().isPlaying) {
			gameObject.GetComponent<ParticleSystem> ().Play ();
		}
	}

	[ClientRpc]
	void RpcStopFire()	{
		Debug.Log ("Rpc Stopping Sound");

		if (gameObject.GetComponent<ParticleSystem> ().isPlaying) {
			gameObject.GetComponent<ParticleSystem> ().Stop ();
		}
	}

	public void StartFire()	{
		if (!isServer)
			return;

		Debug.Log ("Starting Fire");
		RpcStartFire ();
	}

	public void StopFire()	{
		if (!isServer)
			return;

		Debug.Log ("Stopping Fire");
		RpcStopFire ();
	}
		
}
