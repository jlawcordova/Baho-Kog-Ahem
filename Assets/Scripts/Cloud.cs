using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(Random.Range(-9f, 9f), Random.Range(4.2f, 3f), transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
		if(transform.position.x < -9){
			transform.position = new Vector3(9f, Random.Range(4.2f, 3f), transform.position.z);
		}
	}
}
