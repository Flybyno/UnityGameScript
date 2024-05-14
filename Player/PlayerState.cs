using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine StateMachine;
    protected Player Player;
    protected Rigidbody2D RB;
    protected float xInput;
    protected float yInput;
    private string AnimBoolName;
    protected float StateTimer;
    protected bool TriggerCalled; // Frame Trigger Call.

    public PlayerState(Player Player01, PlayerStateMachine StateMachine01, string AnimBoolName01) 
        // Constructor, Because the PlayerState is a Class which is unable to get the value input,
        // To get the value input, we need to use Constructor. And also (Its original meaning) to initialize the value
        // Without define the value when you need a variable specially from other Class area.
    {
        this.Player = Player01;
        this.StateMachine = StateMachine01;// Will be used in other State (like PlayerGroundedState.cs)
                                            // And cause of here is a StateMachine already but there was a StateMachine 
                                            // in Player.cs, so we need to distinguish them by using "this". And get the
                                            // StateMachine from Player.cs. 
                                            
        this.AnimBoolName = AnimBoolName01;
    }

    public virtual void Enter() // Enter Function
    {
        Player.Anim.SetBool(AnimBoolName,true);
        // The Anim from Player is Inherited from Entity and does not written in Player so you cannot find it,
        // And SetBool is a Unity Function.
        // To Call the Specific Animator (Which written) and set bool value into true.
        // Therefore, you can see the change in unity UI that the animation bool state is true then the character plays it.
        RB = Player.RB;
        // RB is from Entity.
        TriggerCalled = false;
        // Unity function named TriggerCalled.
    }

    public virtual void Update() 
        // To get Inout each frame. And it is basic function of all the State.
        // That is why  we make Inheritance to link "PlayerState" as mother and other various State as son.
    {
        StateTimer -= Time.deltaTime;
        
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        Player.Anim.SetFloat("yVelocity",RB.velocity.y);
    }
    
    public virtual void Exit()
    {
        Player.Anim.SetBool(AnimBoolName,false);// When you exit the state, the animation bool state is false.
    }
    
    public virtual void AnimationFinishTrigger()
    {
        TriggerCalled = true;
    }
}
