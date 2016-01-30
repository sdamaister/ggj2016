using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSpeech : MonoBehaviour {
	public Canvas speechCanvas;
	public Text speechText;

	// Use this for initialization
	void Start () {
		speechCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Talk(string speech)
	{
		speechCanvas.enabled = true;
		speechText.text = speech;
	}

	public void ShutUp()
	{
		speechCanvas.enabled = false;
	}
}
