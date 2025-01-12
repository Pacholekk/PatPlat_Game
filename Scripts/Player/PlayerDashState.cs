using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.dashDur;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rbPlayer.velocity.y);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);

        if (player.IsWallDetected() && !player.IsGroundDetected())
            stateMachine.ChangeState(player.wallSlideState);

        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);
    }
}