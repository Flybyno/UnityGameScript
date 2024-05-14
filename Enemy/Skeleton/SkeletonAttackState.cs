using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    private EnemySkeleton Enemy;
    public SkeletonAttackState(Enemy _enemyBase, EnemyStateMachine StateMachine, string AnimBoolName,EnemySkeleton Enemy) : base(_enemyBase, StateMachine, AnimBoolName)
    {
        this.Enemy = Enemy;
    }

    public override void Update()
    {
        base.Update();
        Enemy.SetZeroVelocity();
        if(TriggerCalled)
            StateMachine.ChangeState(Enemy.BattleState);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
