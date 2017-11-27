using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
		if(transform.position.x < -9){
			transform.position = new Vector3(9f, transform.position.y, transform.position.z);
		}
	}
}
