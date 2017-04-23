using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BunsenTouchPoint : NetworkBehaviour {

	protected bool fireplay = false;
	public GameObject fire;
	public GameObject smoke;
	public GameObject metal;
	float timelimit = 2.0f;

	// Use this for initialization
	void Start () {

		fire = Instantiate (fire);
		fire.GetComponent<ParticleSystem>().Stop ();

		smoke = Instantiate (smoke);
		smoke.GetComponent<ParticleSystem>().Stop ();

		//metal = Instantiate (metal);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		
		Debug.Log ("Mouse Clicked");
		fireplay = !fireplay;
		if (fireplay) {
			while (timelimit > 1) {
				fire.GetComponent<ParticleSystem> ().Play ();
				//smoke.GetComponent<ParticleSystem> ().Play ();
				timelimit -= Time.deltaTime;
			}
			//metal.gameObject.active = false;

			//metal.GetComponent <MeshRenderer>.enabled = false;

		} else {
			if (fire.GetComponent<ParticleSystem> ().isPlaying) {
				fire.GetComponent<ParticleSystem> ().Stop ();
			}
		}

	}
		

}
