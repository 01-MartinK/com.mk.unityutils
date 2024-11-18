using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ModelessWindow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerClickHandler
{
    public GameObject handle;
    public Button closeButton;
    private bool isDrag = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter == handle)
        {
            isDrag = true;
        } 
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerEnter == handle)
        {
            isDrag = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDrag) {
            transform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
