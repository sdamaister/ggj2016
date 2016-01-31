using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour {

    public AudioClip footstepClip;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    void PlayFootstep()
    {
        audioSource.PlayOneShot(footstepClip);
    }
}
