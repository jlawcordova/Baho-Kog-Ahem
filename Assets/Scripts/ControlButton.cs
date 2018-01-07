using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool IsDown = false;
	public static bool LeftIsDown = false;
	public static bool RightIsDown = false;

    public Image LeftImage;
    public Image RightImage;
    private RectTransform rect;


    public void OnPointerDown(PointerEventData eventData)
    {
        IsDown = true;
    }

	public void OnPointerUp(PointerEventData eventData)
    {
        IsDown = false;
        LeftIsDown = false;
        RightIsDown = false;
        LeftImage.color = new Color(1,1,1,0.5f);
        RightImage.color = new Color(1,1,1,0.5f);
    }

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(IsDown){
            Vector2 point = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rect, Input.mousePosition, Camera.main, out point);
            if(point.x <= 0)
            {
                LeftIsDown = true;
                RightIsDown = false;
                LeftImage.color = new Color(1,1,1,1);
                RightImage.color = new Color(1,1,1,0.5f);
            }
            else
            {
                RightIsDown = true;
                LeftIsDown = false;
                LeftImage.color = new Color(1,1,1,0.5f);
                RightImage.color = new Color(1,1,1,1);
            }
        }
    }
}
