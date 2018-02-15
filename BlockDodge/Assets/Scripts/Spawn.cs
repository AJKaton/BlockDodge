using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	
	public GameObject fallingprefab;
	Vector2 screenhalfsize;
    public Vector2 spawndelayMinMax;
	public float nextspawntime;
	public Vector2 spawnsizeMinMax;
	public float spawnangleMax;

	// Use this for initialization
	void Start () {
		screenhalfsize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update (){
		if (Time.time > nextspawntime) {
			
			float spawndelay = Mathf.Lerp (spawndelayMinMax.y, spawndelayMinMax.x, Difficulty.GetDifficultyPercent ());
			nextspawntime = Time.time + spawndelay;
			float spawnsize = Random.Range (spawnsizeMinMax.x, spawnsizeMinMax.y);
			float spawnangle = Random.Range (-spawnangleMax, spawnangleMax);
			Vector2 spawnposition = new Vector2 (Random.Range (-screenhalfsize.x, screenhalfsize.x), screenhalfsize.y + spawnsize); 
			GameObject newblock = (GameObject) Instantiate (fallingprefab, spawnposition, Quaternion.Euler (Vector3.forward * spawnangle));
			newblock.transform.localScale = Vector2.one * spawnsize;
		}
	}
}


			
