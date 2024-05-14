using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
        RB.velocity=new Vector2(RB.velocity.x,Player.JumpForce);
    }

    public override void Update()
    {
        base.Update();
        if(RB.velocity.y<0)
            StateMachine.ChangeState(Player.AirState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
