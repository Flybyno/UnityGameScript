using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState :PlayerState
{
    public PlayerAirState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if(Player.IsWallDetected())
            StateMachine.ChangeState(Player.WallSlideState);
        if(Player.IsGroundDetected())
            StateMachine.ChangeState(Player.IdleState);
        if(xInput !=0)
            Player.SetVelocity(Player.MoveSpeed*.8f*xInput,RB.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
