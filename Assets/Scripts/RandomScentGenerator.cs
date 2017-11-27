using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScentGenerator : MonoBehaviour {

	public GameObject ScentObject;
	public float Delay;
	public float Duration;
	public float GenerateTime;
	private float currentTime;
	private float destroyTime;
	private bool Started;

	// Use this for initialization
	void Start () {
		currentTime = 0;
		destroyTime = 0;
		Started = false;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		destroyTime += Time.deltaTime;

		if(Delay <= destroyTime){
			Started = true;
		}

		if(GenerateTime <= currentTime && Started){
			GameObject scent;
			scent = Instantiate(ScentObject, new Vector3(Random.Range(-7, 7), 10, 0), Quaternion.Euler(0, 0, 90f));
			scent.GetComponent<Knife>().XSpeed = 0;
			scent.GetComponent<Knife>().YSpeed = -0.17f;
			currentTime = 0;
		}

		if(Duration <= destroyTime){
			Destroy(gameObject);
		}
	}
}
