using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBornAttackMechanics : EnemyState
{
    private NightBorn nightBorn;
    public NightBornAttackMechanics(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,NightBorn _nightBorn) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.nightBorn = _nightBorn;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        nightBorn.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(0, 0);

        if (trigerCalled)
        {
            stateMachine.ChangeState(nightBorn.attackState);

        }
    }
}
