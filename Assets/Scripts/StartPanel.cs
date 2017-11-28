using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour, IPointerClickHandler {

	public GameObject FadingObject;
	public GameObject MainTextObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void StartPanelClicked () {
		MainTextObject.GetComponent<Animator>().SetTrigger("Blink");
		gameObject.GetComponent<AudioSource>().Play();
		FadingObject.SetActive(true);
	}

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        StartPanelClicked ();
    }
}
