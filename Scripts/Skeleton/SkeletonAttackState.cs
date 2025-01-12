using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    private Transform player;
    private Skeleton enemy;
    CharacterStats playerStats;
    private int moveDir;
    
    
    
    public SkeletonAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
        
    }

    public override void Update()
    {
        base.Update();
         

        if (enemy.IsPlayerDetected() && enemy.IsGroundDetected())
        {
            
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                {
                    rb.velocity = new Vector2(0, 0);
                    stateMachine.ChangeState(enemy.attackMechanic);
                    rb.velocity = new Vector2(0, 0);

                }
                
            }
        }
        else
        {
            if(stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position ) > 10)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
            if(Vector2.Distance(player.transform.position, enemy.transform.position) > 0.5)
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        
        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        enemy.SetVelocity(enemy.attackMoveSpeed * moveDir, rb.velocity.y);
        
    }

    public override void Exit()
    {
        base.Exit();
    }


    private bool CanAttack()
    {
        playerStats = player.GetComponent<CharacterStats>();
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown && playerStats.currentHealth > 0)
        {
            enemy.rb.velocity = new Vector2(0, 0);
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}
