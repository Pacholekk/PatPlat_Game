using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBornMoveState : NightBornGroundedState
{
    public NightBornMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, NightBorn _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
        this.nightBorn = _enemy; 
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (nightBorn.IsWallDetected() || !nightBorn.IsGroundDetected())
        {

            nightBorn.Flip();
        }
        nightBorn.SetVelocity(nightBorn.moveSpeed * nightBorn.facinDir, rb.velocity.y);
    }
    

}
