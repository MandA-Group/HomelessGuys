using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : MonoBehaviour, IState
{
    private Rigidbody _rigidbody;
    private float _forceValue = 400f;
    private StateMachine _stateMachine;
    public void Initialize(StateMachine stateMachine)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        _rigidbody.AddForce(Vector3.up * _forceValue);
    }

    public void OnExit()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _stateMachine.Enter<IdleState>();
        }
    }
}
