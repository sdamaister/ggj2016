using UnityEngine;

using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpeechArea : MonoBehaviour {
	public string speech = "";
	private bool speaking = false;
	public float bubbleTimer = 5.0f;
    public bool bMustGoNextLevel = false;

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
			if(timer <= 0.0f)
			{
				speaking = false;
				characterGameObject.SendMessage("ShutUp");

                if (bMustGoNextLevel)
                {
                    characterGameObject.GetComponent<PlayerKill>().level.OnLevelEnd();
                }
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

	#if UNITY_EDITOR
	void OnSceneGUI ()
    {

   		UnityEditor.Handles.Label(this.transform.position, "asdfasdf");


    }
    #endif

	void OnDrawGizmos() {
        Gizmos.color = new Color(1.0f ,1.0f, 0.0f, 0.25f);
		Gizmos.DrawCube(this.GetComponent<Collider>().bounds.center, this.GetComponent<Collider>().bounds.extents * 2.0f);
        
    }

//	void OnTriggerExit(Collider collider)
//	{
//		collider.gameObject.SendMessage("ShutUp");
//	}
}



