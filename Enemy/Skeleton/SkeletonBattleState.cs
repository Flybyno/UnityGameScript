using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform Player;
    private EnemySkeleton Enemy;
    private int MoveDirection;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine StateMachine, string AnimBoolName, EnemySkeleton Enemy ) : base(_enemyBase, StateMachine, AnimBoolName)
    {
        this.Enemy = Enemy;
    }

    public override void Update()
    {
        base.Update();
        
        if(Player.position.x>Enemy.transform.position.x)
            MoveDirection = 1;
        else if(Player.position.x < Enemy.transform.position.x)
            MoveDirection = -1;
        Enemy.SetVelocity(Enemy.MoveSpeed* MoveDirection, RB.velocity.y);
        
        if (Enemy.IsPlayerDetected())
        {
            StateTimer = Enemy.BattleTime;
            if (Enemy.IsPlayerDetected().distance < Enemy.AttackDistance)
            {
                if(CanAttack())
                    StateMachine.ChangeState(Enemy.AttackState);
            }
        }
        else
        {
            if(StateTimer<0|| Vector2.Distance(Player.transform.position,Enemy.transform.position)>10)
                StateMachine.ChangeState(Enemy.IdleState);
        }
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
    private bool CanAttack()
    {
        if(Time.time>=Enemy.LastTimeAttacked+ Enemy.AttackCooldown)
        {
            Enemy.LastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}
