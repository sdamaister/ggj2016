using UnityEngine;
using System.Collections;

public class LevelBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos() {
        Gizmos.color = new Color(1.0f ,0.0f, 1.0f, 0.25f);
		Gizmos.DrawCube(this.GetComponent<Collider>().bounds.center, this.GetComponent<Collider>().bounds.extents * 2.0f);
        
    }

    void OnTriggerEnter()
    {
    	
    }
}
