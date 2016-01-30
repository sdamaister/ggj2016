using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {

    public float characterGroundSpeed = 2.0f;
    public float characterAirSpeed = 1.5f;

    private Rigidbody rb;
    private float xVelocity, zVelocity;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        xVelocity = Input.GetAxis("Horizontal");
        zVelocity = Input.GetAxis("Vertical");

        Vector3 currentDirection = Quaternion.Euler(0, 45, 0) * Vector3.Normalize(new Vector3(xVelocity, 0.0f, zVelocity));
        Debug.Log("currentDirection is " + currentDirection);
        xVelocity = currentDirection.x;
        zVelocity = currentDirection.z;
	}

    void FixedUpdate()
    {
        rb.velocity = new Vector3(xVelocity * characterGroundSpeed, rb.velocity.y, zVelocity * characterGroundSpeed);
    }
}
