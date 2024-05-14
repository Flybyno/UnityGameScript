using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator Anim { get; private set; }// Unity Class to link Animator.
    public Rigidbody2D RB { get; private set; }// Unity Class to link Rigid body.
    public EntityFX FX { get; private set; }
    
    [Header("HitBack Info")]
    [SerializeField]protected Vector2 KnockBackDirection;
    [SerializeField]protected float KnockBackDuration;
    protected bool IsKoncked;
    
    [Header("Collision Info")]
    public Transform AttackCheck;
    public float AttackCheckRadius;
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected float GroundCheckDistance;
    [SerializeField] protected Transform WallCheck;
    [SerializeField] protected float WallCheckDistance;
    [SerializeField] protected LayerMask WhatIsGround;
    
    public int FacingDirection { get; private set; } = 1;
    private bool FacingRight = true;
    
    
    
    // Set Components Region
    
    protected virtual void Awake()
    {
    }
    
    
    protected virtual void Start()
    {
        FX = GetComponent<EntityFX>();
        Anim = GetComponentInChildren<Animator>();
        
        // Get the Animator component with the way that search its Child. In Unity this script is attached to the Player
        // and Animator is just a Child component of the Player.
        
        RB = GetComponent<Rigidbody2D>();// Get Rigid body itself only.
        
        //When you get this component, the you can call and use this component in transformation or rotate and so on. 
    }
    
    
    protected virtual void Update()
    {
    }

    public virtual void Damage()
    {
        FX.StartCoroutine("FlashFX");
        StartCoroutine("HitKnockBack");
    }
    
    protected virtual IEnumerator HitKnockBack()
    {
        IsKoncked = true;
        RB.velocity = new Vector2(KnockBackDirection.x*-FacingDirection,KnockBackDirection.y);
        
        yield return new WaitForSeconds(KnockBackDuration);
        IsKoncked = false;
    }
    
    // Collision Region
    
    public  virtual bool IsGroundDetected() 
        => Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistance, WhatIsGround);
    public virtual bool IsWallDetected() 
        => Physics2D.Raycast(WallCheck.position, Vector2.right*FacingDirection, WallCheckDistance, WhatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine
            (GroundCheck.position, new Vector2(GroundCheck.position.x, GroundCheck.position.y - GroundCheckDistance));
        // The Position begin;          // The End Position and  you can understand it as the length of the line
                                        // which you have to set the start point first that always use (x,y) and
                                        // then you can plus or minus the number of the length.
                                        
                                        // And! why there is a negative number behind y position?
                                        // Please Caution that:
                                        // IT IS A GROUND CHECK! GROUND ALWAYS UNDER THE CHARACTER!
        Gizmos.DrawLine
            (WallCheck.position, new Vector2(WallCheck.position.x + WallCheckDistance, WallCheck.position.y));
        // Read the above explanation.
        Gizmos.DrawWireSphere(AttackCheck.position,AttackCheckRadius);
        // This is a circle.
    }
    
    
    
    // Flip Region
    
    public virtual void Flip()
    {
        FacingDirection = FacingDirection * -1;
        FacingRight = !FacingRight;
        transform.Rotate(0,180,0);
    }
    
    public virtual void FlipController(float xIn)
    {
        if(xIn>0&&!FacingRight)
            Flip();
        else if (xIn < 0 && FacingRight)
            Flip();
    }
    
    
    
    // Velocity Region
    
    public void SetZeroVelocity()
    {
        if(IsKoncked)
            return;
        
        RB.velocity = new Vector2(0, 0);
    }
    
    public void SetVelocity(float xVelocity01, float yVelocity01)
    {
        if(IsKoncked)
            return;
        
        RB.velocity = new Vector2(xVelocity01, yVelocity01);
        FlipController(xVelocity01);
    }
}
