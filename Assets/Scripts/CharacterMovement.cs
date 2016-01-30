using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {

	[Range (0.0f, 5.0f)]
    public float characterGroundSpeed = 2.0f;

	[Range (0.0f, 4.0f)]
    public float characterAirSpeed = 1.5f;

	[Range (0.0f, 600.0f)]
    public float jumpForce = 600.0f;

    private Rigidbody rb;
    private Vector3 currentDirection;
    private Rigidbody currentAttachedPlatform;
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

        if (xVelocity == 0.0f && zVelocity == 0.0f && currentAttachedPlatform != null)
        {
            rb.velocity = new Vector3(currentAttachedPlatform.velocity.x, rb.velocity.y, currentAttachedPlatform.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(xVelocity * speed, rb.velocity.y, zVelocity * speed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (Vector3.Angle(contact.normal, Vector3.up) <= 5)
                {
                    currentAttachedPlatform = collision.gameObject.GetComponent<Rigidbody>();
                    break;
                }
            }
        }

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

    void OnCollisionExit(Collision collision)
    {
        currentAttachedPlatform = null;
    }
}
