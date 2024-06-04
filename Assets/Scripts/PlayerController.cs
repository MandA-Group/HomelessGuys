using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 25f;
    [SerializeField] private float _rotationSpeed = 60f;
    [SerializeField] private float _jumpForce = 1f;
    
    private bool isGrounded;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Jump();
    }
    
    private void Move()
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
            transform.Translate(Vector3.left * step);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * step);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
