using UnityEngine;
using System.Collections;

public class KillByHeight : MonoBehaviour {
	public string levelToLoad;
	public GameObject character;
	public GameObject killZone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(character.transform.position.y < killZone.transform.position.y)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);
		}
	}
}
