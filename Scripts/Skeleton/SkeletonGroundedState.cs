using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected Skeleton enemy;
    protected Transform player;
    
    
    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;

    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
      
    }

    public override void Update()
    {
        base.Update();

        if (!enemy.IsGroundDetected())
        {
            stateMachine.ChangeState(enemy.moveState);
        }

        else if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 3)
        {
           
            stateMachine.ChangeState(enemy.attackState);
        }
        
    }
}
