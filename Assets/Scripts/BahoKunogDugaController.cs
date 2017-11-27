using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahoKunogDugaController : MonoBehaviour, IGameLevel {

	public GameObject DugaGeneratorObject;
	public GameObject DugaGeneratorInstance;	public float DugaGeneratorAppearTime;
	private bool DugaGeneratorActivated;
	private bool GameLevelEndedFlag;
	public float DugaGeneratorDurationTime;

	public event EventHandler GameLevelEnded;
	

	public float CurrentTime;

	// Use this for initialization
	void Start () {
		CurrentTime = 0;
		DugaGeneratorActivated = false;
		GameLevelEndedFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTime += Time.deltaTime;

		if(DugaGeneratorAppearTime <= CurrentTime && !DugaGeneratorActivated){
			DugaGeneratorInstance = Instantiate(DugaGeneratorObject, new Vector3(0.3f, -1f, 0), Quaternion.identity);
			DugaGeneratorActivated = true;
		}

		if(DugaGeneratorDurationTime <= CurrentTime && !GameLevelEndedFlag){
			OnGameLevelEnded();
			GameLevelEndedFlag = true;
			Destroy(DugaGeneratorInstance);
		}
	}

	public void OnGameLevelEnded(){
		if(GameLevelEnded!=null){
			GameLevelEnded(this, null);
		}
	}
}
