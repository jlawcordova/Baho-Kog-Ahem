using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReporterDialog : MonoBehaviour {

	public float DialogDuration;
	public GameObject BahoDialog;
	private float timer;

	// Use this for initialization
	void Start () {	
		BahoDialog.SetActive(false);	
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(DialogDuration < timer)
		{
			BahoDialog.SetActive(true);
		}
	}
}
