﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _startPos;
    private Vector3 _startPosWorld;
    private float _distToCamera;
    private Vector2 _currOffset;

    private void Start()
    {
        _currOffset = new Vector2();
        _distToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, _distToCamera));
        _startPos = transform.position;
    }

    public void BeginDrag(Vector2 offset)
    {
        _startPos = Camera.main.WorldToScreenPoint(transform.position);
        _startPosWorld = _startPos;
    }
    public void Move(Vector2 offset)
    {
        //Vector2 caclulatedPos = offset + _startPos;
        //bool xGood = caclulatedPos.x < Screen.width && caclulatedPos.x > 0;
        //bool yGood = caclulatedPos.y < Screen.height && caclulatedPos.y > 0;
        //if (xGood)
        //{
        //    _currOffset.x = offset.x;
        //}
        //if (yGood)
        //{
        //    _currOffset.y = offset.y;
        //}
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(_currOffset.x, _currOffset.y, _distToCamera) + _startPosWorld);
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(offset.x, offset.y, _distToCamera));
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }


}
