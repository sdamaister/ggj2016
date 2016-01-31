using UnityEngine;
using System.Collections;

public class FitImageToCamera : MonoBehaviour {

	private SpriteRenderer sprite;

	private float width;
	private float height;
	private float aspect;

	private float screenWidthWorld;
	private float screenHeightWorld;


	float worldScreenHeight;
	float worldScreenWidth;
	float spriteScaleWidth; 

	public float totalOffset;


	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		sprite.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, sprite.transform.position.z);
		width = sprite.sprite.bounds.size.x;
		height = sprite.sprite.bounds.size.y;
		aspect = width/height;

		worldScreenHeight = Camera.main.orthographicSize * 2.0f;

		float screenAspect = (float)Screen.width / (float) Screen.height;


		if(screenAspect > aspect)
		{
			worldScreenWidth = worldScreenHeight * Screen.width/Screen.height;
			spriteScaleWidth = worldScreenHeight * aspect;
			ResizeSpriteToScreen(spriteScaleWidth / width, worldScreenHeight / height);
		}else
		{
			float w = Camera.main.orthographicSize * 2.0f;
			float h = w / aspect;
			ResizeSpriteToScreen(w / width, h / height);
		}


	}

	// Update is called once per frame
	void Update () {

	}


	void ResizeSpriteToScreen(float width, float height) {

		Vector3 newLocalScale = new Vector3(width, height);
		transform.localScale = newLocalScale;

	}


}
