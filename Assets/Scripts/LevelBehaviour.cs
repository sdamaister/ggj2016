using UnityEngine;
using System.Collections;

public class LevelBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayerKill()
	{
		Debug.Log ("OnPlayerKill, restarting");
		UnityEngine.SceneManagement.SceneManager.LoadScene (ThisLevelName);
	}

	public void OnLevelEnd()
	{
		Debug.Log ("OnLevelEnd, change to " + NextSceneName);
		UnityEngine.SceneManagement.SceneManager.LoadScene (NextSceneName);
	}


	public string ThisLevelName;
	public string NextSceneName;
}
