using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(Enemy _enemyBase, EnemyStateMachine StateMachine, string AnimBoolName, EnemySkeleton Enemy) : base(_enemyBase, StateMachine, AnimBoolName, Enemy)
    {
    }

    public override void Update()
    {
        base.Update();
        if(StateTimer<0)
            StateMachine.ChangeState(Enemy.MoveState);
    }

    public override void Enter()
    {
        base.Enter();
        StateTimer = Enemy.IdleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
