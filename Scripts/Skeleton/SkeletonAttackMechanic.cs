using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackMechanic : EnemyState
{
    private Skeleton enemy;
    public SkeletonAttackMechanic(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        rb.velocity = new Vector2(0, 0);

        if (trigerCalled)
        {
            stateMachine.ChangeState(enemy.attackState);

        }

       
    }
}
