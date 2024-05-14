using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StateTimer = Player.DashDuration;
    }

    public override void Update()
    {
        base.Update();
        if(!Player.IsGroundDetected()&&Player.IsWallDetected())
            StateMachine.ChangeState(Player.WallSlideState);
        Player.SetVelocity(Player.DashSpeed * Player.DashDirection,0);
        if (StateTimer < 0) 
            StateMachine.ChangeState(Player.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
        Player.SetVelocity(0,RB.velocity.y);
    }
}

