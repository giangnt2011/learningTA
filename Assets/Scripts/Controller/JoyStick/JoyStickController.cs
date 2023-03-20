using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Controller;
using Unity.Mathematics;
using Unity.VisualScripting;

public class JoyStickController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image outerCircle;
    [SerializeField] private float bgImageSizeX, bgImageSizey;
    [SerializeField] private Image innerCircle;
    Vector3 startPosition;


    public Vector2 InputDirection { set; get; }
    private void Start()
    {
        startPosition = innerCircle.transform.position;
        bgImageSizeX = outerCircle.rectTransform.sizeDelta.x;
        bgImageSizey = outerCircle.rectTransform.sizeDelta.y;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        innerCircle.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 distance = (Vector3)eventData.position - startPosition;
        
        var offSet = bgImageSizeX / 3;
        var disPos = Vector3.Distance(eventData.position, startPosition);
        if(disPos > offSet)
        {
            var newPos = startPosition + offSet * distance.normalized;
            innerCircle.transform.position = newPos;
        }
        else
        {
            innerCircle.transform.position = eventData.position;
        }

        SetInputDirection(distance.x,distance.y);

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        innerCircle.transform.position = startPosition;
        SetInputDirection(0,0);
    }
    public void SetInputDirection(float x, float y)
    {
        InputDirection = new Vector3(x, y).normalized;
    }
}
