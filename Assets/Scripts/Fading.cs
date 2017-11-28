using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {


    void Awake(){
        gameObject.SetActive(false);
    }
	// Use this for initialization
    void Start()
    {
        StartCoroutine(FadingOut());
    }

    // Wait until the object fades to move to the next scene.
    IEnumerator FadingOut()
    {
        yield return new WaitUntil(() => transform.GetComponent<Image>().color.a == 1);
        SceneManager.LoadScene("Game");
    }
}
