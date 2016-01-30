﻿using UnityEngine;
using System.Collections;

public class LanzadorPalillos : MonoBehaviour 
{
	public GameObject [] obj;
	public float tiempoMin = 1f;
	public float tiempoMax = 2f;
	public float fVelocidad=20.0f;

	[Range(0.0f, 10.0f)]
	public float SpawnPeriod = 1.0f;
	
	public Rigidbody PalilloPrefab;
	
	[Range(-10.0f, 10.0f)]
	public float PalilloXSpeed;
	[Range(-10.0f, 10.0f)]
	public float PalilloYSpeed;
	
	[Range(0.0f, 100.0f)]
	public float PalilloTimeToLive = 10.0f;

	
	// Use this for initialization
	void Start () 
	{
	    InvokeRepeating ("Generar", 0.1f, 1);
	}
	
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void Generar()
	{
		Instantiate(obj[Random.Range(0,obj.Length)], transform.position, obj[Random.Range(0,obj.Length)].transform.rotation);

	}
	void Spawn()
	{
		var pb = PalilloPrefab.GetComponent<Palillo> ();
		pb.PalilloVelocity = new Vector3(PalilloXSpeed, PalilloYSpeed, 0.0f);
		pb.TimeToLive = PalilloTimeToLive;
		Instantiate (PalilloPrefab, transform.position, transform.rotation);
	}
	

}
