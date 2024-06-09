using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(-1.5f, 7, -20);
    [SerializeField] private float _sensitivity = 3;
    [SerializeField] private float _limit = 80;
    [SerializeField] private float _zoomMax = 20;
    [SerializeField] private float _zoomMin = 5;
    private float _x, _y;

    void Start () 
    {
        
        _limit = Mathf.Abs(_limit);
        if(_limit > 90) _limit = 90;
        transform.position = _target.position + _offset;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _offset.z = _zoomMin;
        }
        else
        {
            _offset.z = -Mathf.Abs(_zoomMax);
        }
    }

    void LateUpdate ()
    {
        var horizontal = Input.GetAxis(DataConstants.HORIZONTAL);
        var vertical = Input.GetAxis(DataConstants.VERTICAL);

        _x = transform.localEulerAngles.y + horizontal * _sensitivity;
        _y += vertical * _sensitivity;
        _y = Mathf.Clamp (_y, -_limit, _limit);
        _target.Rotate(0, horizontal * _sensitivity,0);
        transform.localEulerAngles = new Vector3(-_y, _x, 0);
        transform.position = transform.localRotation * _offset + _target.position;
    }
}

