using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask WhatIsPlayer;

    [Header("Stunned Info")] 
    public float StunDuration;
    public Vector2 StunDirection;
    protected bool CanBeStunned;
    [SerializeField] protected GameObject CounterImage;
    
    [Header("Move Info")]
    public float MoveSpeed;
    public float IdleTime;
    public float BattleTime;
    [Header("Attack Info")] 
    public float AttackDistance;
    public float AttackCooldown;
    [HideInInspector]public float LastTimeAttacked;
    public EnemyStateMachine StateMachine { get;private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();
    }
    
    protected virtual void Update()
    {
        base.Update();
        StateMachine.currentState.Update();
        
    }
    
    public virtual void OpenCounterAttackWindow()
    {
        CanBeStunned = true;
        CounterImage.SetActive(true);
    }

    public virtual void CloseCounterAttackWindow()
    {
        CanBeStunned = false;
        CounterImage.SetActive(false);
    }

    public virtual bool CanBeStunnedVoid()
    {
        if (CanBeStunned)
        {
            CloseCounterAttackWindow();
            return true;
        }

        return false;
    }
    public virtual void AnimationFinishTrigger() => StateMachine.currentState.AnimationFinishTrigger();

    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDirection, 50, WhatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x + AttackDistance * FacingDirection,transform.position.y));
    }
}
