using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duga : MonoBehaviour {

	public bool IsLeft;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.GetComponent<Rigidbody2D>().rotation += 0.7f * (IsLeft ? 1:-1);
		if(gameObject.transform.position.y < -10){
			Destroy(gameObject);
		}
	}
}
