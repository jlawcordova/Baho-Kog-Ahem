using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	public GameObject[] GameLevels;
	public GameObject Scorer;
	private bool started;
	private bool trigged;

	public float StartTimeDuration;
	public float StartAnimationTimeDuration;
	private float timer;
	private GameObject gameLevel;

	public GameObject BahoGirl;

	private int RandomLevelNumber;

	

	// Use this for initialization
	void Start () {
		started = false;
		trigged = false;
		timer = 0;
		RandomLevelNumber = UnityEngine.Random.Range(0, GameLevels.Length);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(StartTimeDuration < timer && !started)
		{
			gameLevel = Instantiate(GameLevels[RandomLevelNumber]);
			gameLevel.transform.GetChild(0).GetComponent<IGameLevel>().GameLevelEnded += GameEndedEvent;
			Scorer.GetComponent<Scorer>().Started = true;
			started = true;
		}

		if(StartAnimationTimeDuration < timer && !trigged)
		{
			Debug.Log("Triggered");
			switch (RandomLevelNumber)
			{
				case 0:
					BahoGirl.GetComponent<Animator>().SetTrigger("Duga");
					break;
				default:
					BahoGirl.GetComponent<Animator>().SetTrigger("Default");
					break;
			}

			trigged = true;
		}
	}

	public void GameEndedEvent(object sender, EventArgs e){
		Debug.Log("Ended!");
		Destroy(gameLevel);
		BahoGirl.GetComponent<Animator>().SetTrigger("Default");		
		started = false;
		trigged = false;
		timer = 0;
		RandomLevelNumber = UnityEngine.Random.Range(0, GameLevels.Length);		
	}
}
