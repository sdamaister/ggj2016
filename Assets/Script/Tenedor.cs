using UnityEngine;
using System.Collections;

public class Tenedor : MonoBehaviour
{
	public float fVelocidad=20.0f;
	bool bArriba=false;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
		
	{
		
		if (bArriba == false) 
		{
			transform.Translate (Vector3.forward* fVelocidad * Time.deltaTime);
			
			if (transform.position.y < -1) 
			{
				bArriba = true;	
			}
		} 
		
		else 
		{
			transform.Translate (Vector3.forward*-1 * fVelocidad * Time.deltaTime);
			
			if (transform.position.y > 1)
			{
				bArriba = false;
			}
			
		}
		
		
	}

}
