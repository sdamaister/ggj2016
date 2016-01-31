using UnityEngine;
using System.Collections;

public class SpriteToCamera : MonoBehaviour {

	public GameObject LevelStart;
	public GameObject LevelEnd;

	private SpriteRenderer sprite;

	private float width;
	private float height;
	private float aspect;

	private float screenWidthWorld;
	private float screenHeightWorld;

	private float minX;
	private float maxX;
	private float levelWidth;

	float worldScreenHeight;
	float worldScreenWidth;
	float spriteScaleWidth; 

	public float totalOffset;


	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		width = sprite.sprite.bounds.size.x;
		height = sprite.sprite.bounds.size.y;
		aspect = width/height;

		worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		worldScreenWidth = worldScreenHeight * Screen.width/Screen.height;
		spriteScaleWidth = worldScreenHeight * aspect;



		ResizeSpriteToScreen();

		minX = LevelStart.transform.position.x;
		maxX = LevelEnd.transform.position.x;
		levelWidth = maxX - minX;



	}

	// Update is called once per frame
	void Update () {

		float cameraX = Camera.main.transform.position.x;
		float normalizedLevelX = (cameraX - minX)/levelWidth;

		transform.localPosition = 
			new Vector3(
				0.0f + -1.0f * normalizedLevelX * sprite.sprite.bounds.extents.x, 
				transform.localPosition.y,
				transform.localPosition.z);


	}


	void ResizeSpriteToScreen() {

		Vector3 newLocalScale = new Vector3(spriteScaleWidth / width,worldScreenHeight / height);
		transform.localScale = newLocalScale;

	}


}
