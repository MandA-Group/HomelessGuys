using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class CharacterMoving : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    [SerializeField] private float _rotationSpeed = 60f;

    private void Update()
    {
        var step = _speed * Time.deltaTime;
        var rotationStep = _rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * step);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * step);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationStep);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationStep);
        }
    }
}
