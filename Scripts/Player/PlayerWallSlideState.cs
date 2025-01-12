using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }
        if (xInput != 0 && player.facinDir != xInput)
            stateMachine.ChangeState(player.idleState);

        if (!player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);

        if (player.IsGroundDetected() || player.IsSpikesDetected())
            stateMachine.ChangeState(player.idleState);

        if(yInput < 0)
          rbPlayer.velocity = new Vector2(0, rbPlayer.velocity.y );
        else
        rbPlayer.velocity = new Vector2(0, rbPlayer.velocity.y * 0.7f);
    }
}
