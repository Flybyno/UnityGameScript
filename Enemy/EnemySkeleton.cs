using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{
    // State Region
    public SkeletonIdleState IdleState { get; private set; }
    public SkeletonMove MoveState { get; private set; }
    public SkeletonBattleState BattleState { get; private set; }
    public SkeletonAttackState AttackState { get; private set; }
    
    public SkeletonStunnedState StunnedState { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        IdleState = new SkeletonIdleState(this, StateMachine, "Idle", this);
        MoveState = new SkeletonMove(this, StateMachine, "Move", this);
        BattleState = new SkeletonBattleState(this, StateMachine, "Move", this);
        AttackState = new SkeletonAttackState(this, StateMachine, "Attack", this);
        StunnedState = new SkeletonStunnedState(this, StateMachine, "Stunned", this);
    }

    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();
        
    }

    public override bool CanBeStunnedVoid()
    {
        if (base.CanBeStunnedVoid())
        {
            StateMachine.ChangeState(StunnedState);
            return true;
        }

        return false;
    }
}
