using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBornGroundedState : EnemyState
{
    protected NightBorn nightBorn;
    protected Transform player;
    public NightBornGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,NightBorn _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.nightBorn = _enemy;
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
    }
}
