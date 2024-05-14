using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected EnemySkeleton Enemy;
    protected Transform Player;
    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine StateMachine, string AnimBoolName,EnemySkeleton Enemy) : base(_enemyBase, StateMachine, AnimBoolName)
    {
        this.Enemy = Enemy;
    }

    public override void Update()
    {
        base.Update();
        if(Enemy.IsPlayerDetected()||Vector2.Distance(Enemy.transform.position,Player.position)<2)
            StateMachine.ChangeState(Enemy.BattleState);
    }

    public override void Enter()
    {
        base.Enter();
        Player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
