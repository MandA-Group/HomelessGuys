using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _baseSpeed = 25f;
    [SerializeField] private float _sprint = 35f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _gravity = 20f;
    
    private Vector3 moveDirection = Vector3.zero;
    private float _currentSpeed;
    private int _counter;
    
    private void Start()
    {
        _currentSpeed = _baseSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        Run();
    }
    
    private void Move()
    {
        if (_characterController.isGrounded)
        {
            _counter = 1;
            var verticalInput = Input.GetAxis("Vertical");
            var horizontalInput = Input.GetAxis("Horizontal");

            moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= _currentSpeed;
        }

        if (Input.GetButtonDown("Jump") && _counter == 1)
        {
            moveDirection.y = _jumpForce;
            _counter--;
        }

        moveDirection.y -= _gravity * Time.deltaTime;
        _characterController.Move(moveDirection * Time.deltaTime);
    }
    

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = _sprint;
        }
        else
        {
            _currentSpeed = _baseSpeed;
        }
    }
}
