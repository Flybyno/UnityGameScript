using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState // Use the Logic from PlayerState.
{
    public PlayerGroundedState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
        RB.velocity = new Vector2(0, 0);
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.D))
            StateMachine.ChangeState(Player.CounterAttack);
        if(Input.GetKeyDown(KeyCode.A))
            StateMachine.ChangeState(Player.PrimaryAttackState);
        if(!Player.IsGroundDetected())
            StateMachine.ChangeState(Player.AirState);
        if(Input.GetKeyDown(KeyCode.Space) && Player.IsGroundDetected())
            StateMachine.ChangeState(Player.JumpState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
