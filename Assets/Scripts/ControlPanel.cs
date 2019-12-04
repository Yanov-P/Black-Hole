using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPanel : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
{
    
    private Vector2 _startPos = new Vector2();

    bool holding = false;

    [SerializeField]
    private PlayerMovement _playerMovement;

    [SerializeField]
    private const float MAX_CLICK_OFFSET = 20;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _playerMovement.BeginDrag(_startPos );
    }

    public void OnDrag(PointerEventData eventData) // tut
    {
        _playerMovement.Move(eventData.position - _startPos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _playerMovement.EndDrag();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //_curPos = eventData.position;
        holding = false;
    }
}
