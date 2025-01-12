using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBornAttackState : EnemyState
{
    private NightBorn nightBorn;
    private Transform player;
   
    CharacterStats playerStats;
    private int moveDir;
    public NightBornAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, NightBorn _nightBorn) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.nightBorn = _nightBorn;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindWithTag("Player").transform;
    }

    

    public override void Update()
    {
        base.Update();
        player = GameObject.FindWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found!");
        }

        if (nightBorn.IsPlayerDetected())
        {
           

            if (nightBorn.IsPlayerDetected().distance < nightBorn.attackDistance)
            {
                if (CanAttack())
                {
                    rb.velocity = new Vector2(0, 0);
                    stateMachine.ChangeState(nightBorn.attackMechanics);
                    rb.velocity = new Vector2(0, 0);

                }

            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, nightBorn.transform.position) > 5)
            {
                stateMachine.ChangeState(nightBorn.moveState);
            }
            if (Vector2.Distance(player.transform.position, nightBorn.transform.position) > 0.5)
            {
                rb.velocity = new Vector2(0, 0);
            }
        }


        if (player.position.x > nightBorn.transform.position.x)
            moveDir = 1;
        else if (player.position.x < nightBorn.transform.position.x)
            moveDir = -1;

        nightBorn.SetVelocity(nightBorn.attackMoveSpeed * moveDir, rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }
    private bool CanAttack()
    {
        playerStats = player.GetComponent<CharacterStats>();
        if (Time.time >= nightBorn.lastTimeAttacked + nightBorn.attackCooldown && playerStats.currentHealth > 0)
        {
            nightBorn.rb.velocity = new Vector2(0, 0);
            nightBorn.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}

