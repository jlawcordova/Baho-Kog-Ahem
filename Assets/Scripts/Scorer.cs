﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour {

	public GameObject ScoreTextObject;

	private Text scoreText;

	public static int Score;

	private float Timer;
	public bool Started = false;

	// Use this for initialization
	void Start () {
		Timer = 0.0f;
		scoreText = ScoreTextObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Started){
			Timer += Time.deltaTime;
		}
		
		Score = Convert.ToInt32(Timer);
		scoreText.text = Score.ToString();
	}
}
