using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{


    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Rigidbody2D rbPlayer;
    protected float xInput;
    protected float yInput;
    private string animBoolName;
    protected float stateTimer;
    protected bool trigerCalled;




    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }
  
    public virtual void Enter()
    {
        
        player.anim.SetBool(animBoolName, true);
        rbPlayer = player.rb;
        trigerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rbPlayer.velocity.y);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        trigerCalled = true;
    }
}
