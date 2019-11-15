using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlPanel : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //private Vector2 _offset = new Vector2();
    //private Vector2 _currentOffset = new Vector2();

    private Vector2 _screenSizes;
    private Vector2 _currentOffset = new Vector2();
    private Vector2 _startPos = new Vector2();

    [SerializeField]
    private PlayerMovement _playerMovement;

    [SerializeField]
    private const float MAX_CLICK_OFFSET = 20;

    private void Start()
    {
        _screenSizes = new Vector2(Screen.width, Screen.height);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //_playerMovement.BeginDrag();
        _startPos = eventData.position;
        _playerMovement.BeginDrag(_currentOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _currentOffset = eventData.position - _startPos;
        _playerMovement.Move(_currentOffset);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if ((eventData.position - _startPos).magnitude < MAX_CLICK_OFFSET)
        {
            //click happened
        }
    }
}
