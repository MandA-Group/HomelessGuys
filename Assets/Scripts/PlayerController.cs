using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        var stateMachine = new StateMachine
            (
                GetComponent<WalkingState>(),
                GetComponent<IdleState>(),
                GetComponent<JumpingState>()
            );
        stateMachine.Initialize();
        //stateMachine.Enter<IdleState>();
    }
    
}