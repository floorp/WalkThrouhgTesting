﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed =3f;
	public float speed = 50f;
	public float jumpPower = 200f;
	
	public bool	grounded;
	
	private Rigidbody2D rb2d;
	private Animator anim;
	void Start () {

		//assignment of game objects
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator> ();

	}
	
	void Update () {
	
		//animations
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));

		//flip sprite
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale =new Vector3(-1,1,1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale =new Vector3(1,1,1);
		}
		if (Input.GetButtonDown("Jump") && grounded){
			rb2d.AddForce(Vector2.up * jumpPower);
		}
	}
	
	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		//move player Horizontal
		rb2d.AddForce((Vector2.right * speed) * h);
		//limit speed of player horizontal
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}
}
