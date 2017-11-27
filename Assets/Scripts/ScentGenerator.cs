using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentGenerator : MonoBehaviour {

	public GameObject ScentObject;
	private GameObject ReporterObject;
	public float GenerateTime;
	private float currentTime;

	// Use this for initialization
	void Start () {
		currentTime = 0;

		ReporterObject = GameObject.Find("Reporter");
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if(GenerateTime <= currentTime){
			GameObject scent;
			float angle = Mathf.Atan2((ReporterObject.transform.position.y - transform.position.y), (ReporterObject.transform.position.x - transform.position.x)) + Random.Range(-0.15f, 0.15f);
			scent = Instantiate(ScentObject, transform.position, Quaternion.Euler(0, 0, angle*57.2957f));
			scent.GetComponent<Knife>().XSpeed = 0.17f * Mathf.Cos(angle);
			scent.GetComponent<Knife>().YSpeed = 0.17f * Mathf.Sin(angle);
			currentTime = 0;
		}
	}
}
