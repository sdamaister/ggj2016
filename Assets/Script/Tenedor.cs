using UnityEngine;
using System.Collections;

public class Tenedor : MonoBehaviour
{
	public float fVelocidad=20.0f;
	public Vector2 RangeFork = new Vector2(-1.0f,1.0f);
	public bool bArriba=false;
	
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
			
			if (transform.position.y < RangeFork.x) 
			{
				bArriba = true;	
			}
		} 
		
		else 
		{
			transform.Translate (Vector3.forward*-1 * fVelocidad * Time.deltaTime);
			
			if (transform.position.y > RangeFork.y)
			{
				bArriba = false;
			}
			
		}
		
		
	}

}
