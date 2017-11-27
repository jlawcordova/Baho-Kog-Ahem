using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public static bool IsDown = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        IsDown = true;
    }

	public void OnPointerUp(PointerEventData eventData)
    {
        IsDown = false;
    }
}
