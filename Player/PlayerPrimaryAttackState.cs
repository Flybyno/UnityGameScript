using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int ComboCounter;
    private float LastTimeAttacked;
    private float ComboWindow = 2;
    public PlayerPrimaryAttackState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
        xInput = 0; //fix the issue where the player can attack in wrong direction.
        
        if(ComboCounter>2||Time.time >= LastTimeAttacked + ComboWindow)
            ComboCounter = 0;
        Player.Anim.SetInteger("ComboCounter",ComboCounter);
        //Player.Anim.speed = 1.12f;
        
        float AttackDirection = Player.FacingDirection;
        if(xInput!=0)
            AttackDirection = xInput;
        
        Player.SetVelocity(Player.AttackMovement[ComboCounter].x*AttackDirection,Player.AttackMovement[ComboCounter].y);
        StateTimer = .1f;
    }

    public override void Update()
    {
        base.Update();
        if(StateTimer<0)
            Player.SetZeroVelocity();
        if(TriggerCalled)
            StateMachine.ChangeState(Player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
        Player.StartCoroutine("BusyFor", .25f);
        //Player.Anim.speed = 1;
        ComboCounter++;
        LastTimeAttacked =Time.time;
    }
}
