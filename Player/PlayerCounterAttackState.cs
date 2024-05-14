using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    public PlayerCounterAttackState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) : base(Player01, StateMachine01, AnimBoolName01)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StateTimer = Player.CounterAttackDuration;
        Player.Anim.SetBool("SuccessfulCounterAttack",false);
    }

    public override void Update()
    {
        base.Update();
        Collider2D[] Colliders = Physics2D.OverlapCircleAll(Player.AttackCheck.position, Player.AttackCheckRadius);
        foreach (var hit in Colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                if (hit.GetComponent<Enemy>().CanBeStunnedVoid())
                {
                    StateTimer = 10;
                    Player.Anim.SetBool("SuccessfulCounterAttack",true);
                }
            }
        }
        if(StateTimer<0||TriggerCalled)
            StateMachine.ChangeState(Player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
