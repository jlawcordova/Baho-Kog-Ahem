using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void StartPanelClicked () {
		SceneManager.LoadScene("Game");
	}

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        StartPanelClicked ();
    }
}
