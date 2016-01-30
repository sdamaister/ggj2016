using UnityEngine;
using System.Collections;

public class PlayerKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.CompareTag(GameTags.PlayerKill))
		{
			// run player killing method
		}
	}
}
