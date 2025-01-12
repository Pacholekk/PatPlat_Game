using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboCd = .7f;

    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboCd)
            comboCounter = 0;
        
        player.anim.SetInteger("comboCounter", comboCounter);

        
    }

    public override void Exit()
    {
        base.Exit();

        
        lastTimeAttacked = Time.time; // register time of last attack
        comboCounter++;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            rbPlayer.velocity= new Vector2(0, 0); // not moving while attacking 

        if (trigerCalled)
            stateMachine.ChangeState(player.idleState);

    }
}
