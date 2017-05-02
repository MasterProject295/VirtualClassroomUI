using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AskQuestion : NetworkBehaviour {

	public int currentQuestion = 0;
	private GameObject whiteBoard;
	private Text answerView;
	private Text questionView;

	// Use this for initialization
	void Start () {
		whiteBoard = GameObject.FindGameObjectWithTag ("greenboard");
		GameObject answergameobject = GameObject.FindGameObjectWithTag ("answertext");
		GameObject questiongameobject = GameObject.FindGameObjectWithTag ("questiontext");
		answerView = answergameobject.GetComponent<Text> ();
		questionView = questiongameobject.GetComponent<Text> ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void getValues(){
		Debug.Log (answerView.text);
		Debug.Log (questionView.text);
	}

	[Command]
	public void CmdSendQuestion(int current){

		Debug.Log ("Current Value is--> " + current);
		
	}
}
