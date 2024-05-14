using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine StateMachine;
    protected Enemy enemyBase;
    protected Rigidbody2D RB;
    
    protected bool TriggerCalled;
    private string AnimBoolName;
    protected float StateTimer;

    public EnemyState(Enemy _enemyBase, EnemyStateMachine StateMachine, string AnimBoolName )
    {
        this.enemyBase = _enemyBase;
        this.StateMachine = StateMachine;
        this.AnimBoolName = AnimBoolName;
    }

    public virtual void Update()
    {
        StateTimer -= Time.deltaTime;
    }
    
    public virtual void Enter()
    {
        TriggerCalled = false;
        RB = enemyBase.RB;
        enemyBase.Anim.SetBool(AnimBoolName,true);
    }

    public virtual void Exit()
    {
        enemyBase.Anim.SetBool(AnimBoolName,false);
    }
    
    public virtual void AnimationFinishTrigger()
    {
        TriggerCalled = true;
    }
}
