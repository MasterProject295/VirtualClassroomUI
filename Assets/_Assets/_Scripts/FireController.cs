﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FireController : NetworkBehaviour {

	protected bool fireplay = false;
	public GameObject fire;
	public GameObject smoke;
	public GameObject metal;
	public GameObject powderAnimation;
	public GameObject mgo;
	public GameObject cup;
    private GvrAudioSource gvrAudio;
	// Use this for initialization
	void Start () {
        gvrAudio = GetComponent<GvrAudioSource>();
		fire = Instantiate (fire);
		NetworkServer.Spawn (fire);
		if (fire.GetComponent<ParticleSystem> ().isPlaying) {
			fire.GetComponent<ParticleSystem> ().Stop ();

		}
    }
	
	// Update is called once per frame
	void Update () {
		metal = GameObject.FindGameObjectWithTag ("metal");	
		cup = GameObject.FindGameObjectWithTag ("cup");
	}

	void OnMouseDown(){
		

		Debug.Log ("Mouse Clicked");
		fireplay = !fireplay;
		if (fireplay) {
			StartFire();
		} else {
			StopFire ();
		}
        


	}

	public void CmdStartFire()	{
		StartFire ();
	}

	[Command]
	public void CmdStartSmoke()	{
		StartCoroutine(smokegenerator ());
	}

	public void StopFire(){
		//NetworkServer.Destroy (fire);

		if(isServer){
			if (gvrAudio.isPlaying) {
				gvrAudio.Stop ();
			}

			if (fire.GetComponent<ParticleSystem> ().isPlaying) {
				fire.GetComponent<ParticleSystem> ().Stop ();

			}
		}
	}

	public void StartFire()	{
		
			

		if (isServer) {

			gvrAudio = fire.GetComponent<GvrAudioSource>();
			if (!gvrAudio.isPlaying)
			{
				Debug.Log ("Playing the sound");
				gvrAudio.Play();
			}
		}
			fire.GetComponent<PlaySoundScript> ().PlaySound ();
			if (!fire.GetComponent<ParticleSystem> ().isPlaying) {
				fire.GetComponent<ParticleSystem> ().Play ();
		
			}	
	}

	IEnumerator smokegenerator(){

		if (fire.GetComponent<ParticleSystem> ().isPlaying) {

			yield return new WaitForSeconds (3);
			Quaternion rotation = Quaternion.Euler (-90, 0, 0);
			smoke = Instantiate (smoke, metal.transform.position, rotation);
			if (!smoke.GetComponent<ParticleSystem> ().isPlaying) {
				smoke.GetComponent<ParticleSystem> ().Play ();
			}

			StartCoroutine (metalburning ());
		}

	}

	IEnumerator metalburning(){

		yield return new WaitForSeconds (3);

		//Quaternion rotation = Quaternion.Euler (-90, 0, 0);
		powderAnimation = Instantiate (powderAnimation, metal.transform.position,  Quaternion.identity);
		if (!powderAnimation.GetComponent<ParticleSystem> ().isPlaying) {
			powderAnimation.GetComponent<ParticleSystem> ().Play ();
		}

		StartCoroutine(metaldisappearing ());
	}

	IEnumerator metaldisappearing(){

		yield return new WaitForSeconds (5);
	
		mgo = Instantiate (mgo, metal.transform.position, Quaternion.identity);
		Destroy (metal);

		StartCoroutine(particleresidueeffect ());

	}

	IEnumerator particleresidueeffect(){

		yield return new WaitForSeconds (3);

		if (powderAnimation.GetComponent<ParticleSystem> ().isPlaying) {
			powderAnimation.GetComponent<ParticleSystem> ().Stop ();
			Destroy (powderAnimation);
		}

		if (smoke.GetComponent<ParticleSystem> ().isPlaying) {
			smoke.GetComponent<ParticleSystem> ().Stop ();
			Destroy (smoke);
		}
	}


}
