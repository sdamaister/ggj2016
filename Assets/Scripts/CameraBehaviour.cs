﻿using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject character;
    public float cameraDistance = 10.0f;
	public float cameraSpeed = 5.0f;
	private CharacterMovement cm;
	private Vector3 newPosition;
	// Use this for initialization
	void Start () {
        if (!character)
        {
            Debug.LogWarning("Is necessary to attach a character to CameraBehaviour component");
        }
		cm = character.GetComponent<CharacterMovement> ();
		transform.position = character.transform.position - transform.forward * cameraDistance;

		newPosition = transform.position;
        Physics.gravity = new Vector3(0, -9.81F, 0);
    }

	void FixedUpdate () {
		Vector3 transf = character.transform.position - transform.forward * cameraDistance;
		if (!cm.bJumping) {
			transf.y = transform.position.y;
		}
		transform.position = Vector3.Lerp(newPosition, transf, Time.deltaTime * cameraSpeed);
		newPosition = transform.position;
		//transform.position = transf;
	}
}
