using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeGenerator : MonoBehaviour {

	public GameObject KnifeObject;
	public float GenerateTime;
	public float DelayTime;
	private float delayTimer;
	private float currentTime;
	private bool HasStarted;


	// Use this for initialization
	void Start () {
		currentTime = 0;
		delayTimer = 0;
		HasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		delayTimer += Time.deltaTime;
		currentTime += Time.deltaTime;

		if(!HasStarted && DelayTime <= delayTimer){
			HasStarted = true;
		}

		if(GenerateTime <= currentTime && HasStarted){
			GameObject knife;
			float angle = Random.Range(-Mathf.PI/2, 0.0f);
			knife = Instantiate(KnifeObject, transform.position, Quaternion.Euler(0, 0, (angle*57.2957f)));
			knife.GetComponent<Knife>().XSpeed = 0.2f * Mathf.Cos(angle);
			knife.GetComponent<Knife>().YSpeed = 0.2f * Mathf.Sin(angle);
			currentTime = 0;
		}

		if(transform.position.y <= -3.4f){
			Destroy(gameObject);
		}
	}
}
