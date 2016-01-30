using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject character;
    public float cameraDistance = 10.0f;

	// Use this for initialization
	void Start () {
        if (!character)
        {
            Debug.LogWarning("Is necessary to attach a character to CameraBehaviour component");
        }
	}
	
	void LateUpdate () {
        transform.position = character.transform.position - transform.forward * cameraDistance;
	}
}
