using UnityEngine;
using System.Collections;

public class LanzadorPalillos : MonoBehaviour 
{
	public GameObject [] obj;
	public float tiempoMin = 1f;
	public float tiempoMax = 2f;
	public float fVelocidad=20.0f;

	
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
}

