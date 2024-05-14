using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        Player.SetVelocity(xInput*Player.MoveSpeed,RB.velocity.y);
        if(xInput==0)
            StateMachine.ChangeState(Player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
