using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {
	public Vector2 speedMinMax;
	public float capspeed;
	float visiblebounds;
	void Start () { 
		capspeed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent ());
		visiblebounds = -Camera.main.orthographicSize - transform.localScale.y;
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector2.down * capspeed * Time.deltaTime);
		if (transform.position.y < visiblebounds) {
			Destroy (gameObject);
		}
	}
}
