using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public float fast = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float temp = Input.acceleration.x;
		transform.Translate (temp * fast, 0, 0);
		
	}
}
