using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    Skeleton skeleton;
    CharacterStats skeletonStats;

    #region States
    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    public SkeletonAttackMechanic attackMechanic { get; private set; }
    public SkeletonDeathState deathState { get; private set; }



    #endregion


    protected override void Awake()
    {
        base.Awake();
        idleState = new SkeletonIdleState(this, stateMachine, "isIdle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "isMoving", this);
        attackState = new SkeletonAttackState(this, stateMachine, "isMoving", this);
        attackMechanic = new SkeletonAttackMechanic(this, stateMachine, "isAttacking", this);
        deathState = new SkeletonDeathState(this, stateMachine, "isDead", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        
      SkeletonDie();
        
        
    }

  public void SkeletonDie()
    {
        GameObject skeleton = GameObject.FindWithTag("Enemy");
        skeletonStats = skeleton.GetComponent<CharacterStats>();
        if (stats.currentHealth <= 0)
        {
            stateMachine.ChangeState(deathState);
            SetVelocity(0, 0);
            Destroy(gameObject, 1.5f);
            
        }

    }

    
}

