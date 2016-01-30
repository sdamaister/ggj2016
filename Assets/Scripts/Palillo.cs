using UnityEngine;
using System.Collections;

public class Palillo : MonoBehaviour 
{
	public Vector3 PalilloVelocity;
	public float TimeToLive;
	
	private Rigidbody rb;
	
	
	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, TimeToLive);
		rb = GetComponent<Rigidbody> ();
		rb.velocity = PalilloVelocity;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void FixedUpdate() 
	{
		rb.MovePosition (rb.position + PalilloVelocity * Time.deltaTime);
	}

}
