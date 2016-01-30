using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {

    public float characterGroundSpeed = 2.0f;
    public float characterAirSpeed = 1.5f;
    public float jumpForce = 20.0f;

    private Rigidbody rb;
    private Vector3 currentDirection;
    private float xVelocity, zVelocity;
    private bool bApplyJump;
    private bool bJumping;
    private bool bBlockMovement;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        bApplyJump = false;
        bJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        float newXVelocity = -Input.GetAxis("Vertical");
        float newZVelocity = Input.GetAxis("Horizontal");

        Vector3 newCurrentDirection = Quaternion.Euler(0, 45, 0) * Vector3.Normalize(new Vector3(newXVelocity, 0.0f, newZVelocity));

        if ((bJumping && newCurrentDirection.magnitude > 0) || !bJumping)
        {
            currentDirection = newCurrentDirection;
            xVelocity = currentDirection.x;
            zVelocity = currentDirection.z;
        }

        if (Input.GetButtonDown("Jump") && !bJumping)
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

        float speed = bJumping ? characterAirSpeed : characterGroundSpeed;
        rb.velocity = new Vector3(xVelocity * speed, rb.velocity.y, zVelocity * speed);
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
