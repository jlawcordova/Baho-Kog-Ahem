using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DugaGenerator : MonoBehaviour {

	public GameObject Duga;
	public GameObject CurrentDuga;
	public float GenerateTime;
	public float MinimumXPosition;
	public float MaximumXPosition;


	private float CurrentTime;
	// Use this for initialization
	void Start () {
		CurrentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTime += Time.deltaTime;

		if(CurrentTime >= GenerateTime)
		{
			CurrentTime = 0;
			CurrentDuga = Instantiate(Duga, new Vector3(-0.25f, -0.5f, 0), Quaternion.Euler(0, 0, -110));
			CurrentDuga.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 400) * -1, Random.Range(100, 700)));
			CurrentDuga.GetComponent<Duga>().IsLeft = true;
			
			CurrentDuga = Instantiate(Duga, new Vector3(0.25f, -0.5f, 0), Quaternion.Euler(0, 0, 110));
			CurrentDuga.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 400), Random.Range(100, 700)));
			CurrentDuga.GetComponent<Duga>().IsLeft = false;
		}
	}
}
