using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBornDeathState : EnemyState
{
    private NightBorn nightBorn;
    public NightBornDeathState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, NightBorn _nightBorn) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.nightBorn = _nightBorn;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
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
