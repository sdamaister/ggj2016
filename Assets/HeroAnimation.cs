using UnityEngine;
using System.Collections;

public class HeroAnimation : MonoBehaviour {
	private Animator animator;
	private Vector3 lastPosition;
	public float speedX;
	private bool lookingRight = true;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		lastPosition = transform.position;
	}

	void Update()
	{
		animator.SetFloat("Velocity", Mathf.Abs(speedX));

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		speedX = Input.GetAxis("Horizontal");
		lastPosition = transform.position;

		if(speedX > 0.0f && !lookingRight)
		{
			Flip();
		}
		else
		{
			if(speedX < 0.0f && lookingRight)
			{
				Flip();
			}
		}
	}

	void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 currentScale = transform.localScale;
		currentScale.x = currentScale.x * -1.0f;
		transform.localScale = currentScale;
	}
}
