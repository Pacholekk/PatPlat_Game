using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBornIdleState : NightBornGroundedState
{
    public NightBornIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, NightBorn _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
        this.nightBorn = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = nightBorn.idleTime;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < nightBorn.idleTime)
        {

            stateMachine.ChangeState(nightBorn.moveState);
        }
    }

}
