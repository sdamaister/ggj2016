using UnityEngine;
using System.Collections;

public class SpeechArea : MonoBehaviour {
	public string speech = "";
	public bool speaking = false;
	public float bubbleTimer = 5.0f;

	private GameObject characterGameObject;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(speaking)
		{
			timer -= Time.deltaTime;
			Debug.logger.Log(timer);
			if(timer <= 0.0f)
			{
				speaking = false;
				characterGameObject.SendMessage("ShutUp");
			}
		}

	}

	void OnTriggerEnter(Collider collider)
	{
		if(!speaking)
		{
			characterGameObject = collider.gameObject;
		    speaking = true;
			characterGameObject.SendMessage("Talk", speech);
			timer = bubbleTimer;
		}
	}

//	void OnTriggerExit(Collider collider)
//	{
//		collider.gameObject.SendMessage("ShutUp");
//	}
}
