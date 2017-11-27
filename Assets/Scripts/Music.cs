﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	public static Music instance;
	
	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
		}
		else if(instance!=this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
