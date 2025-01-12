using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SkeletonDeathState : EnemyState
{
    protected Skeleton enemy;
   

    public SkeletonDeathState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        
        
        enemy.capsuleCollider.enabled = false;

        stateTimer = 1f;
       
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer > 0)
            rb.velocity = new Vector2(0, 0);

    }

}
