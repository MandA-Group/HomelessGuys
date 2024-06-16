using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

public class WalkingState : MonoBehaviour, IState
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force = 30f;
    private StateMachine _stateMachine;
    private Vector3 _moveDirection;
    private bool _isStateMove;

    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        _inputController.Moving += isChangeMoving;
        _inputController.ClickOnSpace += ToJumpingState;
    }
    
    private void isChangeMoving()
    {
        _isStateMove = true;
    }

    private void Update()
    {
        if (!_isStateMove)
        {
            return;
        }
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        if (!_isStateMove)
        {
            return;
        }
        if (_moveDirection.x != 0 || _moveDirection.z != 0)
        {
            MovingPlayer();
        }
        else
        {
            StopMoving();
            _isStateMove = false;
            _stateMachine.Enter<IdleState>();
        }
    }

    public void OnExit()
    {
        _inputController.ClickOnSpace -= ToJumpingState;
        _inputController.Moving -= isChangeMoving;
    }
    

    private void MovingPlayer()
    {
        _rigidbody.AddRelativeForce(_moveDirection * _force);
    }

    private void StopMoving()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void ToJumpingState()
    {
        _stateMachine.Enter<JumpingState>();
    }
}
