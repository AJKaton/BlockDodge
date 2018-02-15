using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public event System.Action OnPlayerDeath;
	public float speed = 7;
	float screenhalfwitdth;


	// Use this for initialization
	void Start () {
		float halfplayerwidth = transform.localScale.x / 2f;
		screenhalfwitdth = Camera.main.aspect * Camera.main.orthographicSize - halfplayerwidth;
	}
	
	// Update is called once per frame
	void Update () {
		float InputX = Input.GetAxisRaw ("Horizontal");
		float velocity = InputX * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);
		if (transform.position.x < -screenhalfwitdth) {
			transform.position = new Vector2 (-screenhalfwitdth, transform.position.y);
		}

		if (transform.position.x > screenhalfwitdth) {
			transform.position = new Vector2 (screenhalfwitdth, transform.position.y);
		}
	}

		void OnTriggerEnter2D (Collider2D triggerCollider)
	{
		if (triggerCollider.tag == "Falling Block") {
			if (OnPlayerDeath != null) {
				OnPlayerDeath ();
			}
		
			Destroy (gameObject);
		
		}
	}
}
