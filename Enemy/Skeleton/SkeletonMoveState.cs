using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMove : SkeletonGroundedState
{
    public SkeletonMove(Enemy _enemyBase, EnemyStateMachine StateMachine, string AnimBoolName, EnemySkeleton Enemy) : base(_enemyBase, StateMachine, AnimBoolName, Enemy)
    {
    }

    public override void Update()
    {
        base.Update();
        Enemy.SetVelocity(Enemy.MoveSpeed * Enemy.FacingDirection, RB.velocity.y);
        if(Enemy.IsWallDetected()||!Enemy.IsGroundDetected())
        {
            Enemy.Flip();
            StateMachine.ChangeState(Enemy.IdleState);
        }
        if(enemyBase.IsPlayerDetected())
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
