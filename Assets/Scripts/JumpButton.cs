using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler {
	private Reporter reporter;
    public void OnPointerDown(PointerEventData eventData)
    {
        reporter.PerformJump();
    }

    // Use this for initialization
    void Start () {
		reporter = GameObject.Find("Reporter").GetComponent<Reporter>();
	}
}
