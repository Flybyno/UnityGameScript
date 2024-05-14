using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StateMachine.ChangeState(Player.WallJumpState);
            return;
        }
        
        if (xInput != 0&&Player.FacingDirection != xInput)
            StateMachine.ChangeState(Player.IdleState);
        if (Player.IsWallDetected() && xInput != 0 && Player.FacingDirection == xInput)
            RB.velocity = new Vector2(0, RB.velocity.y*.9f);
        else
            RB.velocity = new Vector2(0,RB.velocity.y);
        if(Player.IsGroundDetected())
            StateMachine.ChangeState(Player.IdleState);
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
