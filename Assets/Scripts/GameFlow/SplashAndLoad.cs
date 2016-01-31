using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashAndLoad : MonoBehaviour {
	public string sceneToLoad;
    public float TimeToMakeTransition = 3;

    private float elapsedTime;

	// Use this for initialization
	void Start () {
        elapsedTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= TimeToMakeTransition)
        {
			SceneManager.LoadScene(sceneToLoad);
        }
	}
}
