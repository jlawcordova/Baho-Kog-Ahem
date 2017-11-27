using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkongAnakKawatanController : MonoBehaviour, IGameLevel {
    public GameObject Anak;
    private GameObject AnakInstance;
    public float AnakAppearTime;
	public float LevelDuration;
	public event EventHandler GameLevelEnded;
	private bool GameLevelEndedFlag;
	private bool AnakActivated;
    public Difficulty DifficultyLevel {get; set;}

	public float CurrentTime;

    // Use this for initialization
    void Start () {
		CurrentTime = 0;
		AnakActivated = false;
		GameLevelEndedFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTime += Time.deltaTime;

		if(AnakAppearTime <= CurrentTime && !AnakActivated){
			AnakInstance = Instantiate(Anak);

			switch (DifficultyLevel)
			{
				case Difficulty.Easy:
					AnakInstance.GetComponent<KnifeGenerator>().GenerateTime = 0.25f;
					break;
				case Difficulty.Moderate:
					AnakInstance.GetComponent<KnifeGenerator>().GenerateTime = 0.19f;
					break;
				case Difficulty.Hard:
					AnakInstance.GetComponent<KnifeGenerator>().GenerateTime = 0.13f;
					break;
				case Difficulty.Insane:
					AnakInstance.GetComponent<KnifeGenerator>().GenerateTime = 0.08f;
					break;
				default:
					Debug.Log("Warning. Difficulty incorrect.");
					AnakInstance.GetComponent<KnifeGenerator>().GenerateTime = 1f;
					break;
			}
			
			AnakActivated = true;
		}

		if(LevelDuration <= CurrentTime && !GameLevelEndedFlag){
			OnGameLevelEnded();
			GameLevelEndedFlag = true;
			AnakInstance.GetComponent<Animator>().SetTrigger("Escape");
		}
	}

	public void OnGameLevelEnded(){
		if(GameLevelEnded!=null){
			GameLevelEnded(this, null);
		}
	}
}
