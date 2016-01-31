using UnityEngine;
using System.Collections;

public class LanzadorPalillos : MonoBehaviour 
{
	[Range(0.0f, 10.0f)]
	public float SpawnPeriod = 1.0f;
	
	public Rigidbody PalilloPrefab;
	
	[Range(-10.0f, 10.0f)]
	public float PalilloXSpeed;
	[Range(-10.0f, 10.0f)]
	public float PalilloZSpeed;
	
	[Range(0.0f, 100.0f)]
	public float PalilloTimeToLive = 10.0f;

	
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Spawn", 0, SpawnPeriod);
	}

	void Spawn()
	{
		var pb = PalilloPrefab.GetComponent<Palillo> ();
		pb.PalilloVelocity = new Vector3(PalilloXSpeed, 0.0f, PalilloZSpeed);
		pb.TimeToLive = PalilloTimeToLive;
		Instantiate (PalilloPrefab, transform.position, transform.rotation);
	}

}

