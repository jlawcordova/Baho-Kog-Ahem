using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public float XSpeed;
	public float YSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += new Vector3(XSpeed, YSpeed, 0);
		if(transform.position.x > 12 || transform.position.x < -12 ||
			transform.position.y > 12 || transform.position.y < -12){
			Destroy(gameObject);
		}
	}
}
