using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement2D : MonoBehaviour {

    public float characterGroundSpeed = 2.0f;
    public float characterAirSpeed = 1.5f;
    public float jumpForce = 500.0f;

    private Rigidbody rb;
    private Vector3 currentDirection;
    private float xVelocity;
    private bool bApplyJump;
    private bool bJumping;
    private bool bBlockMovement;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
        bApplyJump = false;
        bJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        float newXVelocity = Input.GetAxis("Horizontal");
        currentDirection.x = 0.0f;

        Vector3 newCurrentDirection = Vector3.Normalize(new Vector3(newXVelocity, 0.0f, 0.0f));

        if ((bJumping && newCurrentDirection.magnitude > 0) || !bJumping)
        {
            currentDirection = newCurrentDirection;
            xVelocity = currentDirection.x;
        }

        if (!bJumping && Input.GetButtonDown("Jump"))
        {
            bApplyJump = true;
        }
	}

    void FixedUpdate()
    {
        if (bBlockMovement)
        {
            return;
        }

        if (bApplyJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            bApplyJump = false;
            bJumping = true;
        }
//
        float speed = bJumping ? characterAirSpeed : characterGroundSpeed;
        rb.velocity = new Vector3(xVelocity * speed, rb.velocity.y, 0.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Angle(contact.normal, Vector3.up) <= 45)
            {
                bJumping = false;
                bBlockMovement = false;
                break;
            }
            else if (bJumping)
            {
                bBlockMovement = true;
            }
        }
    }
}
