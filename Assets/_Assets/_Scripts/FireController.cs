using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FireController : NetworkBehaviour {

	protected bool fireplay = false;
	public GameObject fireprefab;
	public GameObject smokeprefab;
	public GameObject metal;
	public GameObject powderAnimationprefab;
	public GameObject mgoprefab;
	public GameObject cup;
	public GameObject explosionprefab;
	public GameObject tube;
    private GvrAudioSource gvrAudio;
	GameObject fire;
	GameObject smoke;
	GameObject powderAnimation;
	GameObject mgo;
	GameObject explosion;
	// Use this for initialization
	void Start () {
        gvrAudio = GetComponent<GvrAudioSource>();
		}
	
	// Update is called once per frame
	void Update () {
		metal = GameObject.FindGameObjectWithTag ("metal");	
		cup = GameObject.FindGameObjectWithTag ("cup");
		tube = GameObject.FindGameObjectWithTag ("tube");
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

	/*public void CmdStartFire()	{
		StartFire ();
	}

	[Command]
	public void CmdStartSmoke()	{
		StartCoroutine(smokegenerator ());
	}*/

	public void StopFire(){
		if(isServer){

			if (gvrAudio.isPlaying) {
				gvrAudio.Stop ();
			}

			fire.GetComponent<FireFlamesScript> ().StopSound ();

			NetworkServer.Destroy (fire);
			Destroy (fire);
		}
	}

	public void StartFire()	{
		

		if (isServer) {

			fire = Instantiate (fireprefab);
			NetworkServer.Spawn (fire);

			gvrAudio = fire.GetComponent<GvrAudioSource>();

			if (!gvrAudio.isPlaying)
			{
				Debug.Log ("Playing the sound");
				gvrAudio.Play();
			}

			fire.GetComponent<FireFlamesScript> ().PlaySound ();
			if (!fire.GetComponent<ParticleSystem> ().isPlaying) {
				fire.GetComponent<ParticleSystem> ().Play ();
			}
		}	
	}
		
	public void StartSmoke()	{
		StartCoroutine (smokegenerator());
	}


	IEnumerator smokegenerator(){

		if (fire != null && fire.GetComponent<ParticleSystem> ().isPlaying) {

			yield return new WaitForSeconds (10);
			Quaternion rotation = Quaternion.Euler (-90, 0, 0);
			if (smoke == null) {
				smoke = Instantiate (smokeprefab, metal.transform.position, rotation);
				NetworkServer.Spawn (smoke);
			}

			if (!smoke.GetComponent<ParticleSystem> ().isPlaying) {
				smoke.GetComponent<ParticleSystem> ().Play ();
			}

			StartCoroutine (metalburning ());
		}

	}

	IEnumerator metalburning(){

		yield return new WaitForSeconds (10);

		//Quaternion rotation = Quaternion.Euler (-90, 0, 0);
		if (powderAnimation == null) {
			powderAnimation = Instantiate (powderAnimationprefab, metal.transform.position, Quaternion.identity);
			NetworkServer.Spawn (powderAnimation);
		}

		if (!powderAnimation.GetComponent<ParticleSystem> ().isPlaying) {
			powderAnimation.GetComponent<ParticleSystem> ().Play ();
		}

		StartCoroutine(metaldisappearing ());
	}

	IEnumerator metaldisappearing(){

		yield return new WaitForSeconds (5);

		if (mgo == null) {
			mgo = Instantiate (mgoprefab, metal.transform.position, Quaternion.identity);
			NetworkServer.Spawn (mgo);
		}
		NetworkServer.Destroy (metal);
		Destroy (metal);

		StartCoroutine(particleresidueeffect ());

	}

	IEnumerator particleresidueeffect(){

		yield return new WaitForSeconds (10);

		if (powderAnimation.GetComponent<ParticleSystem> ().isPlaying) {
			powderAnimation.GetComponent<ParticleSystem> ().Stop ();

			NetworkServer.Destroy (powderAnimation);
			Destroy (powderAnimation);
		}

		if (smoke.GetComponent<ParticleSystem> ().isPlaying) {
			smoke.GetComponent<ParticleSystem> ().Stop ();

			NetworkServer.Destroy (smoke);
			Destroy (smoke);
		}
	}

	public void StartExplosion(){
		StartCoroutine (explosionbegins());
	}

	IEnumerator explosionbegins(){

		yield return new WaitForSeconds (2);
		if (fire != null && fire.GetComponent<ParticleSystem> ().isPlaying) {

			Quaternion rotation = Quaternion.Euler (-90, 0, 0);
			if (explosion == null) {
				explosion = Instantiate (explosionprefab, tube.transform.position, rotation);
				NetworkServer.Spawn (explosion);
				PlayExplosionSound ();
			}
			NetworkServer.Destroy (tube);
			Destroy (tube);

			yield return new WaitForSeconds (2);

			StopExplosionSound ();

			if (explosion.GetComponent<ParticleSystem> ().isPlaying) {
				explosion.GetComponent<ParticleSystem> ().Stop ();
			}
			NetworkServer.Destroy (explosion);
			Destroy (explosion);

		}

	}

	public void PlayExplosionSound(){
		explosion.GetComponent<ExplosionScript> ().PlayExplosionSound ();
	}

	public void StopExplosionSound(){
		explosion.GetComponent<ExplosionScript> ().StopExplosionSound ();
	}
		
}
