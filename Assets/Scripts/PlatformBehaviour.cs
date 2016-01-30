using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, TimeToLive);
		rb = GetComponent<Rigidbody> ();
		//rb.velocity = PlatformVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		rb.MovePosition (rb.position + PlatformVelocity * Time.deltaTime);
	}
	public Vector3 PlatformVelocity;
	public float TimeToLive;

	private Rigidbody rb;
}
