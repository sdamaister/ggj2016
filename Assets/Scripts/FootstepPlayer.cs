using UnityEngine;
using System.Collections;

public class FootstepPlayer : MonoBehaviour {

    public AudioClip footstepClip;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	void PlayFootstep()
    {
        source.PlayOneShot(footstepClip);
    }
}
