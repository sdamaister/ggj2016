using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) 
	{
		if(collision.gameObject.CompareTag(GameTags.LevelEnd))
		{
			// run level end method
		}
	}
}
