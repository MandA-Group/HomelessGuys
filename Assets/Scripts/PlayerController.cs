using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _baseSpeed = 25f;
    [SerializeField] private float _sprint = 35f;
    [SerializeField] private float _rotationSpeed = 60f;
    [SerializeField] private float _jumpForce = 1f;
    private float _currentSpeed;
    private bool isGrounded;
    
    private void Start()
    {
        _currentSpeed = _baseSpeed;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Jump();
        Run();
    }
    
    private void Move()
    {
        var step = _currentSpeed * Time.deltaTime;
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
            transform.Translate(Vector3.left * step);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * step);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(DataConstants.TAG_FLOOR))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(DataConstants.TAG_FLOOR))
        {
            isGrounded = false;
        }
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
