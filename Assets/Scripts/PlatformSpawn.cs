using UnityEngine;
using System.Collections;

public class PlatformSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 0, SpawnPeriod);
	}

	void Spawn()
	{
		var pb = PlatformAsset.GetComponent<PlatformBehaviour> ();
		pb.PlatformVelocity = new Vector3(PlatformXSpeed, PlatformYSpeed, 0.0f);
		pb.TimeToLive = PlatformTimeToLive;
		Instantiate (PlatformAsset, transform.position, transform.rotation);
	}

	[Range(0.0f, 10.0f)]
	public float SpawnPeriod = 1.0f;

	public Rigidbody PlatformAsset;

	[Range(-10.0f, 10.0f)]
	public float PlatformXSpeed;
	[Range(-10.0f, 10.0f)]
	public float PlatformYSpeed;

	[Range(0.0f, 100.0f)]
	public float PlatformTimeToLive = 10.0f;
}
