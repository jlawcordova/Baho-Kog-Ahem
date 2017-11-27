using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

	public float LoadDuration;
	private float Timer;
	// Use this for initialization
	void Start () {
		Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;

		if(LoadDuration < Timer){
			SceneManager.LoadScene("Main");
		}
	}
}
