using UnityEngine;
using System.Collections;

public class PlayerKill : MonoBehaviour {

    public AudioClip dieClip;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	

	void OnTriggerEnter(Collider collision) 
	{
		if(collision.gameObject.CompareTag(GameTags.PlayerKill))
		{
            audioSource.PlayOneShot(dieClip);
			level.OnPlayerKill();
		}
	}

	public LevelBehaviour level;
}
