using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahoKunogDugaController : MonoBehaviour, IGameLevel {

	public GameObject DugaGeneratorObject;
	public GameObject DugaGeneratorInstance;
	public float DugaGeneratorAppearTime;
	private bool DugaGeneratorActivated;
	private bool GameLevelEndedFlag;
	public float DugaGeneratorDurationTime;

	public event EventHandler GameLevelEnded;
	

	public float CurrentTime;

    public Difficulty DifficultyLevel {get; set;}

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
			
			switch (DifficultyLevel)
			{
				case Difficulty.Easy:
					DugaGeneratorInstance.GetComponent<DugaGenerator>().GenerateTime = 0.37f;
					break;
				case Difficulty.Moderate:
					DugaGeneratorInstance.GetComponent<DugaGenerator>().GenerateTime = 0.3f;
					break;
				case Difficulty.Hard:
					DugaGeneratorInstance.GetComponent<DugaGenerator>().GenerateTime = 0.22f;
					break;
				case Difficulty.Insane:
					DugaGeneratorInstance.GetComponent<DugaGenerator>().GenerateTime = 0.13f;
					break;
				default:
					Debug.Log("Warning. Difficulty incorrect.");
					DugaGeneratorInstance.GetComponent<DugaGenerator>().GenerateTime = 1f;
					break;
			}

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
