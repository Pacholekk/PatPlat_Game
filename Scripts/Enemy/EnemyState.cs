using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    protected bool trigerCalled;
    protected float stateTimer;
    protected Rigidbody2D rb;
    private string animBoolName;
    

    public EnemyState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
       

    }

    public virtual void Enter()
    {

        trigerCalled = false;
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(animBoolName, true);
    }
    


    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);
       
    }

    public virtual void Update()
    {

        stateTimer -= Time.deltaTime;
     
    }

    public virtual void AnimationFinishTrigger()
    {
        trigerCalled = true;
    }
}
