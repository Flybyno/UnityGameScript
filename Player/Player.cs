using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Attack Info")] 
    public float CounterAttackDuration=.2f;
    public Vector2[] AttackMovement;
   
    
    public bool IsBusy { get;private set; }
    [Header("Move Info")]
    
    public float JumpForce;
    public float MoveSpeed;
    
    [Header("Dash Info")]
    [SerializeField]private float DashCoolDown;
    private float DashUsageTimer;
    public float DashSpeed;
    public float DashDuration;
    public float DashDirection { get; private set; }
    
    
    
    // Set States Region
    // In fact this is a PlayerState Class in other name.
    public PlayerStateMachine StateMachine { get; private set; } 
    
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerPrimaryAttackState PrimaryAttackState { get; private set; }
    
    public PlayerCounterAttackState CounterAttack { get; private set; }
    
    
    
    private void Awake()// As Activate
    {
     
        // "this" means the Player itself. And give itself to the PlayerState to ues.
        // And other two work as the same. 
        
        base.Awake();
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this,StateMachine,"Idle");
        MoveState = new PlayerMoveState(this,StateMachine,"Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState = new PlayerAirState(this, StateMachine,"Jump");
        DashState = new PlayerDashState(this, StateMachine, "Dash");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, "WallSlide");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, "Jump");
        PrimaryAttackState = new PlayerPrimaryAttackState(this, StateMachine, "Attack");
        CounterAttack = new PlayerCounterAttackState(this, StateMachine, "CounterAttack");
        
        // When you awake this, they will save in the memory and prepare to be called next time you use "StateMachine".
    }
    
    
    
    // Common Region
    
    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(IdleState);  // Set the Start State. As you can see in the screen first time you enter.
    }

    protected override void Update()
    {
        CheckForDash();
        StateMachine.CurrentState.Update();
        // To Use the Update Function of Specific State.
    }

    public IEnumerator BusyFor(float Seconds01)
    {
        IsBusy = true;
        yield return new WaitForSeconds(Seconds01);
        IsBusy = false;
    }
    
    private void CheckForDash()
    {
        DashUsageTimer -= Time.deltaTime;//decrease num from zero to infinite negative.
        if (IsWallDetected())
            return;
        
        if (Input.GetKeyDown(KeyCode.LeftShift)&&DashUsageTimer<0)
        {
            DashUsageTimer = DashCoolDown;
            DashDirection = Input.GetAxisRaw("Horizontal");
            if(DashDirection==0)
                DashDirection = FacingDirection;
            StateMachine.ChangeState(DashState);
        }
    }
    
    public void AnimationTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    
}
