using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _screenToWorldCoeffs;

    [SerializeField]
    [Tooltip("Left bottom constraint of ship movement")]
    private Vector2 _leftBottom;

    [SerializeField]
    [Tooltip("Right top constraint of ship movement")]
    private Vector2 _rightTop;

    private Vector3 _startPos;
    private Vector2 _lastOffs;
    private Vector2 _delta;

    [SerializeField]
    [Tooltip("Minimum delta magnitude to rotate")]
    private float _minDeltaMagnitude = 5;

    private Quaternion _targetRotation;

    [SerializeField]
    [Tooltip("The bigger this value the smoother ship rotates")]
    private float _smooth;

    private void Start()
    {
        var screenSizes = new Vector2(Screen.width, Screen.height);
        _screenToWorldCoeffs = new Vector2( - Mathf.Abs(_rightTop.x - _leftBottom.x) / screenSizes.x, Mathf.Abs(_rightTop.y - _leftBottom.y) / screenSizes.y);
    }
    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _smooth * Time.deltaTime);
    }
    public void BeginDrag(Vector2 offset)
    {
        //on Weapon
        Ship.Instance._gunSwitcher.SwitchWeapon(0);
        _startPos = transform.position;
        _lastOffs = offset;
    }
    public void Move(Vector2 offset)
    {
        _delta = (offset - _lastOffs);
        if(_delta.magnitude > _minDeltaMagnitude)
            _targetRotation = Quaternion.Euler(_delta.y, _delta.x, _delta.x);
        else
            _targetRotation = Quaternion.Euler(0, 0, 0);

        transform.position = MyClamp(_startPos + (Vector3)(offset * _screenToWorldCoeffs), (Vector3)_leftBottom, (Vector3)_rightTop);

        _lastOffs = offset;
    }

    public void EndDrag()
    {
        //off weapon
        Ship.Instance._gunSwitcher.OffAllWeapons();
        _delta = Vector2.zero;
        _targetRotation = Quaternion.Euler(0, 0, 0);
    }

    private Vector3 MyClamp(Vector3 v, Vector3 min, Vector3 max)
    {
        return new Vector3(Mathf.Clamp(v.x, max.x, min.x), Mathf.Clamp(v.y, min.y, max.y), v.z);
    }
}
