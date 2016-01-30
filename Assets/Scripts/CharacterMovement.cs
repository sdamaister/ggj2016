using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {

    public float characterGroundSpeed = 2.0f;
    public float characterAirSpeed = 1.5f;
    public float jumpForce = 20.0f;

    private Rigidbody rb;
    private float xVelocity, zVelocity;
    private bool bApplyJump;
    private bool bJumping;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        bApplyJump = false;
        bJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        xVelocity = Input.GetAxis("Horizontal");
        zVelocity = Input.GetAxis("Vertical");

        Vector3 currentDirection = Quaternion.Euler(0, 45, 0) * Vector3.Normalize(new Vector3(xVelocity, 0.0f, zVelocity));
        Debug.Log("currentDirection is " + currentDirection);
        xVelocity = currentDirection.x;
        zVelocity = currentDirection.z;

        if (Input.GetButtonDown("Jump"))
        {
            bApplyJump = true;
        }
	}

    void FixedUpdate()
    {
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
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            Debug.DrawRay(contact.point, contact.normal, Color.white);

            if (Vector3.Angle(contact.normal, Vector3.up) <= 45)
            {
                bJumping = false;
                break;    
            }
        }
    }
}
