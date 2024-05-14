using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.SetZeroVelocity();
    }

    public override void Update()
    {
        base.Update();
        
        if(xInput!=0 && !Player.IsBusy)
            StateMachine.ChangeState(Player.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
