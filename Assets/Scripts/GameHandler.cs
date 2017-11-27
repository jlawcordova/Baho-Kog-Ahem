using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	private int Level;
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
		Level = 1;
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

			IGameLevel level = gameLevel.transform.GetChild(0).GetComponent<IGameLevel>();
			level.GameLevelEnded += GameEndedEvent;

			if(Level < 2){
				level.DifficultyLevel = Difficulty.Easy;
			}else if(Level < 4){
				level.DifficultyLevel = Difficulty.Moderate;
			}else if(Level < 6){
				level.DifficultyLevel = Difficulty.Hard;
			}else{
				level.DifficultyLevel = Difficulty.Insane;
			}
			Scorer.GetComponent<Scorer>().Started = true;
			started = true;
		}

		if(StartAnimationTimeDuration < timer && !trigged)
		{
			switch (RandomLevelNumber)
			{
				case 0:
					BahoGirl.GetComponent<Animator>().SetTrigger("Bilat");
					break;
				case 1:
					BahoGirl.GetComponent<Animator>().SetTrigger("Duga");
					break;
				case 2:
					BahoGirl.GetComponent<Animator>().SetTrigger("Anak");
					break;
				default:
					BahoGirl.GetComponent<Animator>().SetTrigger("Default");
					break;
			}

			trigged = true;
		}
	}

	public void GameEndedEvent(object sender, EventArgs e){
		Destroy(gameLevel);
		Level++;
		BahoGirl.GetComponent<Animator>().SetTrigger("Default");		
		started = false;
		trigged = false;
		timer = 0;
		RandomLevelNumber = UnityEngine.Random.Range(0, GameLevels.Length);		
	}
}
