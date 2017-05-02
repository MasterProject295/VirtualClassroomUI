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
	private string[] questions = {  "Explain about combustion reaction?",
									"Why is magnesium oxide hazardous?",
									"What is the temperature at which glass melts?",
									"What is Krakatao tube"};
	
	private string[] answers = { "Combustion or burning is a high-temperature exothermic redox chemical reaction between a fuel (the reductant) and an oxidant, usually atmospheric oxygen, that produces oxidized, often gaseous products, in a mixture termed as smoke.",
		""
	};
	


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
		Debug.Log (isLocalPlayer);
		if (isLocalPlayer) {
			Debug.Log ("calling command");
			CmdSendQuestion (currentQuestion);
		}
	}

	[Command]
	public void CmdSendQuestion(int current){
		Debug.Log ("Called command");
			switch (current) {
			case 1:
				answerView.text = answers [0];
				questionView.text = questions [0];
				getValues ();
				break;
			}
			Debug.Log ("Current Value is--> " + current);
		
		}

}
