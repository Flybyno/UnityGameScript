using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    private EnemySkeleton Enemy;
    public SkeletonStunnedState(Enemy _enemyBase, EnemyStateMachine StateMachine, string AnimBoolName,EnemySkeleton Enemy) : base(_enemyBase, StateMachine, AnimBoolName)
    {
        this.Enemy = Enemy;
    }

    public override void Update()
    {
        base.Update();
        if(StateTimer<0)
            StateMachine.ChangeState(Enemy.IdleState);
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.FX.InvokeRepeating("RedColorBlink",0,.1f);
        StateTimer = Enemy.StunDuration;
        RB.velocity=new Vector2(-Enemy.FacingDirection*Enemy.StunDirection.x,Enemy.StunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.FX.Invoke("CancelRedColorBlink",0 );
    }
}
