using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private Reporter reporter;
    public Image UpImage;
    public void OnPointerDown(PointerEventData eventData)
    {
        UpImage.color = new Color(1,1,1,1);
        reporter.PerformJump();
    }

    // Use this for initialization
    void Start () {
		reporter = GameObject.Find("Reporter").GetComponent<Reporter>();
	}

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        UpImage.color = new Color(1,1,1,0.5f);
    }
}
