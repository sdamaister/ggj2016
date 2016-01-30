using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision) 
	{
		if(collision.gameObject.CompareTag(GameTags.LevelEnd))
		{
			level.OnLevelEnd();
		}
	}

	public LevelBehaviour level;
}
