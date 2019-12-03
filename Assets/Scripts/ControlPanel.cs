using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPanel : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 _screenSizes;
    private Vector2 _currentOffset = new Vector2();
    private Vector2 _startPos = new Vector2();
    private Vector2 _curPos = new Vector2();

    bool holding = false;

    [SerializeField]
    private PlayerMovement _playerMovement;

    [SerializeField]
    private const float MAX_CLICK_OFFSET = 20;

    private void Start()
    {
        //_screenSizes = new Vector2(Screen.width, Screen.height);
    }

    private void Update()
    {
        if (holding)
        {
            _playerMovement.Move(_curPos);
        }
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPos = eventData.position;
        _curPos = eventData.position;
        _playerMovement.BeginDrag(_currentOffset);
        Debug.Log("here");
    }

    public void OnDrag(PointerEventData eventData) // tut
    {
        _curPos = eventData.position;
        _playerMovement.Move(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _curPos = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPos = eventData.position;
        _curPos = eventData.position;
        holding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _curPos = eventData.position;
        holding = false;
    }
}
