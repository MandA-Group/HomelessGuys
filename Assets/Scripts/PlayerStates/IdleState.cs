using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : MonoBehaviour, IState
{
    [SerializeField] private Player _player;
    [SerializeField] private InputController _inputController;
    private StateMachine _stateMachine;

    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        _inputController.ClickOnSpace += ToJump;
        _inputController.Moving += ToWalking;
    }

    private void ToJump()
    {
        _stateMachine.Enter<JumpingState>();
    }

    private void ToWalking()
    {
        _stateMachine.Enter<WalkingState>();
    }
    
    public void OnExit()
    {
        _inputController.ClickOnSpace -= ToJump;
        _inputController.Moving -= ToWalking;
    }
}
