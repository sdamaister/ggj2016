using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {

    public GameObject character;
    public float cameraDistance = 10.0f;
	public float cameraSpeed = 5.0f;


	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, -50.0F, 0);
	}

	void FixedUpdate () {
		Vector3 transf = character.transform.position;
		transf.z = transform.position.z;
		transform.position = transf;//

		//transform.position = transf;
	}
}
//
//
//public float cameraDistance = 10.0f;
//-
//+	public float cameraSpeed = 5.0f;
//+	private CharacterMovement cm;
// 	// Use this for initialization
// 	void Start () {
//         if (!character)
//         {
//             Debug.LogWarning("Is necessary to attach a character to CameraBehaviour component");
//         }
//+		cm = character.GetComponent<CharacterMovement> ();
//+		transform.position = character.transform.position - transform.forward * cameraDistance;
// 	}
// 	
//-	void LateUpdate () {
//-        transform.position = character.transform.position - transform.forward * cameraDistance;
//+	void Update () {
//+		Vector3 transf = character.transform.position - transform.forward * cameraDistance;
//+		if (!cm.bJumping) {
//+			transf.y = transform.position.y;
//+		}
//+		transform.position = Vector3.Lerp(transform.position, transf, Time.deltaTime * cameraSpeed);
//+
//+		//transform.position = transf;
// 	}