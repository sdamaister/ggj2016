using UnityEngine;
using System.Collections;

public class FallingPlatformBehaviour : MonoBehaviour {

	private Animator anim;
	private Rigidbody rb;
	private bool bFalling = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bFalling) {
			Debug.Log ("Activating gravity");

			rb.isKinematic = false;
			rb.useGravity = true;
		}
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log ("Entering collision");
		if (col.gameObject.CompareTag(GameTags.Player))
		{
			anim.SetTrigger("Tremble");
		}
	}


	public void OnEndTremble()
	{
		Debug.Log ("Ended tremble");
		bFalling = true;
	}
}
