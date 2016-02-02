
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR

[CustomEditor(typeof(SpeechArea))]
public class SpeechAreaEditor : Editor {
	// Use this for initialization
	void Start (){
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnSceneGUI()
	{
		SpeechArea myTarget = (SpeechArea) target;
		Handles.Label(myTarget.gameObject.transform.position, myTarget.speech);
	}
}
#endif


