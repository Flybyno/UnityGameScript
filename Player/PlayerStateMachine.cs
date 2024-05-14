using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get;private set; } // Inheritance from PlayerState and new named CurrentState. 
    public void Initialize(PlayerState StartState) // Input State named StartState.
    {
        CurrentState = StartState; // Give StartState to CurrentState.
        CurrentState.Enter(); // Run the Enter function of PlayerState.
    }
    public void ChangeState(PlayerState NewState) // Input State named NewState.
    {
        CurrentState.Exit(); // Run the Exit function of PlayerState. Due to the CurrentState must be closed.
        CurrentState = NewState; // Give NewState to CurrentState.
        CurrentState.Enter(); // Run the Enter function of PlayerState.
    }
}
