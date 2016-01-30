using UnityEngine;
using System.Collections;

public class PlatformSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("Spawn", 0, SpawnPeriod);
	}

	void Spawn()
	{
		foreach (Rigidbody rb in PlatformAssets) 
		{
			var pb = rb.GetComponent<PlatformBehaviour> ();
			pb.PlatformVelocity = new Vector3(PlatformXSpeed, 0.0f, PlatformZSpeed);
			pb.TimeToLive = PlatformTimeToLive;
		}
		Instantiate (PlatformAssets[index], transform.position, transform.rotation);
		index = Random.Range(0, PlatformAssets.Length);
		index = index % (PlatformAssets.Length);
	}

	[Range(0.0f, 10.0f)]
	public float SpawnPeriod = 1.0f;


	public Rigidbody[] PlatformAssets;

	[Range(-10.0f, 10.0f)]
	public float PlatformXSpeed;
	[Range(-10.0f, 10.0f)]
	public float PlatformZSpeed;

	[Range(0.0f, 100.0f)]
	public float PlatformTimeToLive = 10.0f;

	private int index = 0;
}
