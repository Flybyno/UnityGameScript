using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StateTimer = 1;
        Player.SetVelocity(5 * Player.FacingDirection*-1, Player.JumpForce);
    }

    public override void Update()
    {
        base.Update();
        if(StateTimer<0)
            StateMachine.ChangeState(Player.AirState);
        if(Player.IsGroundDetected())
            StateMachine.ChangeState(Player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
