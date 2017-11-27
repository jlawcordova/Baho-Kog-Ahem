using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahoHead : MonoBehaviour {

	private GameObject ReporterObject;

	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		ReporterObject = GameObject.Find("Reporter");
	}
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.flipX = (ReporterObject.transform.position.x <= gameObject.transform.position.x);
	}
}
