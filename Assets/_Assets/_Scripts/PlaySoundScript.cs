﻿using System.Collections;
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

	public void PlaySound()	{
		if (!isServer)
			return;

		Debug.Log ("Playing Sound");
		RpcPlaySound ();
	}
}
