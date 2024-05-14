using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState currentState { get; private set; }

    public void Initialize(EnemyState StartState)
    {
        currentState = StartState;
        currentState.Enter();
    }

    public void ChangeState(EnemyState NewState)
    {
        currentState.Exit();
        currentState = NewState;
        currentState.Enter();
    }
}
