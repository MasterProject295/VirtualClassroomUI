using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class VoiceInput : MonoBehaviour {


    public string[] keywords = new string[] { "start bunsen burner", "stop bunsen burner" , "start" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public float speed = 1;
    protected string word = "right";
    private PhraseRecognizer recognizer;
    public Text results;
    public Image Target;
    protected string previous_word = "akshay";

    // Use this for initialization
    void Start()
    {
        results = GetComponent<Text>();
        //results.text = "";
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void OnApplicationQuit() {
        if (recognizer != null && recognizer.IsRunning) {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (!previous_word.Equals(word)) {
            previous_word = word;
            Debug.Log("you said " + word);
        }
	}
}
