using UnityEngine;
using System.Collections;

public class PlayerKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision) 
	{
		if(collision.gameObject.CompareTag(GameTags.PlayerKill))
		{
			level.OnPlayerKill();
		}
	}

	public LevelBehaviour level;
}
