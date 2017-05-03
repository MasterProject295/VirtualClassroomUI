using System.Collections;
using System.Collections.Generic;
using System;
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
	
	private string[] answers = { "Combustion or burning is a high-temperature exothermic redox chemical reaction between a fuel (the reductant) and an oxidant" +
		", usually atmospheric oxygen, that produces oxidized, often gaseous products, in a mixture termed as smoke.",
		"Breathing Magnesium Oxide can irritate eyes and nose. Exposure to it can cause \"metal fume fever\". It is a flu like illness with symptoms of metallic taste in mouth, headache, fever and chills, aches, chest tightness and cough",
		"The melting point for ordinary glass is around 550 degrees centigrade (Celsius) or 1020 Fahrenheit.",
		"Krakatoa Tubes are actually small tubes made of glass with some water inside. The tubes are closed and sealed air-tight. When they are put under fire, the water boils and pressure is built inside the tube. Finally, the glass explodes!"

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
		if (isServer) {
			Debug.Log ("I am server");
			foreach (KeyCode kCode in Enum.GetValues(typeof(KeyCode))) {
				if (Input.GetKeyDown (kCode)) {
					Debug.Log (kCode);
		//			RpcInstructorAnswer (kCode);
				}
			}
		}			
	}
		

	public void setValues(int current){
		switch (current) {
		case 1:
			answerView.text = answers [0];
			questionView.text = questions [0];
			break;
		case 2:
			answerView.text = answers [1];
			questionView.text = questions [1];
			break;
		case 3:
			answerView.text = answers [2];
			questionView.text = questions [2];
			break;
		case 4:
			answerView.text = answers [3];
			questionView.text = questions [3];
			break;
		}
		Debug.Log ("Current Value is--> " + current);
		if (isClient) {
			CmdSendQuestion (current);
		}
	}

	[Command]
	public void CmdSendQuestion(int current){
		whiteBoard = GameObject.FindGameObjectWithTag ("greenboard");
		GameObject answergameobject = GameObject.FindGameObjectWithTag ("answertext");
		GameObject questiongameobject = GameObject.FindGameObjectWithTag ("questiontext");
		answerView = answergameobject.GetComponent<Text> ();
		questionView = questiongameobject.GetComponent<Text> ();

		Debug.Log ("Called command");
		string[] questions = {  "Explain about combustion reaction?",
			"Why is magnesium oxide hazardous?",
			"What is the temperature at which glass melts?",
			"What is Krakatao tube"};

		string[] answers = { "Combustion or burning is a high-temperature exothermic redox chemical reaction between a fuel (the reductant) and an oxidant" +
			", usually atmospheric oxygen, that produces oxidized, often gaseous products, in a mixture termed as smoke.",
			"Breathing Magnesium Oxide can irritate eyes and nose. Exposure to it can cause \"metal fume fever\". It is a flu like illness with symptoms of metallic taste in mouth, headache, fever and chills, aches, chest tightness and cough",
			"The melting point for ordinary glass is around 550 degrees centigrade (Celsius) or 1020 Fahrenheit.",
			"Krakatoa Tubes are actually small tubes made of glass with some water inside. The tubes are closed and sealed air-tight. When they are put under fire, the water boils and pressure is built inside the tube. Finally, the glass explodes!"

		};
		
		switch (current) {
		case 1:
			answerView.text = answers [0];
			questionView.text = questions [0];
			break;
		case 2:
			answerView.text = answers [1];
			questionView.text = questions [1];
			break;
		case 3:
			answerView.text = answers [2];
			questionView.text = questions [2];
			break;
		case 4:
			answerView.text = answers [3];
			questionView.text = questions [3];
			break;
		}
			Debug.Log ("Current Value is--> " + current);
		
		}
}
