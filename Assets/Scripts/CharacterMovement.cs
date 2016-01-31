using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {

	[Range (0.0f, 15.0f)]
    public float characterGroundSpeed = 2.0f;

	[Range (0.0f, 14.0f)]
    public float characterAirSpeed = 1.5f;


	[Range (0.0f, 1500.0f)]
    public float jumpForce = 600.0f;

    private Rigidbody rb;
    private Transform mesh;
    private Animator animator;
    private Vector3 currentDirection;
    private Rigidbody currentAttachedPlatform;
    private float xVelocity, zVelocity;
    private bool bApplyJump;
	//huehue
    public bool bJumping;
    private bool bBlockMovement;


    public AudioClip jumpClip;
    public AudioClip landClip;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponentInChildren<Transform>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
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

        if (Mathf.Abs(newXVelocity) > 0.0f || Mathf.Abs(newZVelocity) > 0.0f)
        {
            animator.SetFloat("speed", 2.0f);
        }
        else
        {
            animator.SetFloat("speed", 0.0f);
        }

        animator.SetBool("bJumping", bJumping);
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
            SetJumping(true);
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

        //mesh.rotation = Quaternion.Euler(rb.velocity);
        mesh.LookAt(mesh.position + new Vector3(rb.velocity.x, 0.0f, rb.velocity.z));
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
                SetJumping(false);
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

    void SetJumping(bool bMustJump)
    {
        bJumping = bMustJump;

        if (bJumping)
        {
            audioSource.PlayOneShot(jumpClip);
        }
        else
        {
            audioSource.PlayOneShot(landClip);
        }
    }
}
