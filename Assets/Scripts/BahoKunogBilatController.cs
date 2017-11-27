using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahoKunogBilatController : MonoBehaviour, IGameLevel {

    public GameObject BilatGirlObject;
	public GameObject BilatGirlInstance;
    public float BilatGirlAppearTime;
    private bool BilatGirlActivated;
    public float LevelDuration;


    public Difficulty DifficultyLevel {get; set;}
    public event EventHandler GameLevelEnded;

    public float CurrentTime;


    // Use this for initialization
    void Start () {
		CurrentTime = 0;
        BilatGirlActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTime += Time.deltaTime;

        if(BilatGirlAppearTime <= CurrentTime && !BilatGirlActivated){
            BilatGirlInstance = Instantiate(BilatGirlObject);
			
			switch (DifficultyLevel)
			{
				case Difficulty.Easy:
					BilatGirlInstance.transform.GetChild(1).transform.GetChild(0).GetComponent<ScentGenerator>().GenerateTime = 0.8f;
					break;
				case Difficulty.Moderate:
					BilatGirlInstance.transform.GetChild(1).transform.GetChild(0).GetComponent<ScentGenerator>().GenerateTime = 0.7f;
					break;
				case Difficulty.Hard:
					BilatGirlInstance.transform.GetChild(1).transform.GetChild(0).GetComponent<ScentGenerator>().GenerateTime = 0.6f;
					break;
				case Difficulty.Insane:
					BilatGirlInstance.transform.GetChild(1).transform.GetChild(0).GetComponent<ScentGenerator>().GenerateTime = 0.51f;
					break;
				default:
					Debug.Log("Warning. Difficulty incorrect.");
					BilatGirlInstance.transform.GetChild(1).transform.GetChild(0).GetComponent<ScentGenerator>().GenerateTime = 1f;
					break;
			}
			BilatGirlActivated = true;
		}

        if(LevelDuration <= CurrentTime){
			OnGameLevelEnded();
			Destroy(BilatGirlInstance);
		}
	}

    public void OnGameLevelEnded(){
		if(GameLevelEnded!=null){
			GameLevelEnded(this, null);
		}
	}
}
