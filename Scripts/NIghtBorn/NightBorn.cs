using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorn : Skeleton
{
    NightBorn nightBorn;
    CharacterStats nightBornStats;

    public NightBornMoveState moveState { get; private set; }
    public NightBornAttackMechanics attackMechanics { get; private set; }
    public NightBornDeathState deathState { get; private set; }
    public NightBornAttackState attackState { get; private set; }
    public NightBornIdleState idleState { get; private set; }
   

    protected override void Awake()
    {
        base.Awake();
        moveState = new NightBornMoveState(this, stateMachine, "isMoving", this);
        attackState = new NightBornAttackState(this, stateMachine, "isAttacking", this);
        attackMechanics = new NightBornAttackMechanics(this, stateMachine, "isAttacking", this);
        deathState = new NightBornDeathState(this, stateMachine, "isDead", this);
        idleState = new NightBornIdleState(this, stateMachine, "isIdle", this);
    }

    protected override void Start()
    {
        base.Start();
        
    }

    protected override void Update()
    {
        base.Update();
        NightBornDie();
    }

    public void NightBornDie()
    {
        if (stats.currentHealth <= 0 )
        {
              // Ustaw flagę, że NightBorn umarł
            stateMachine.ChangeState(deathState);
            SetVelocity(0, 0);
            Invoke("ActivateToBeContinued", 1f);
            Destroy(gameObject, 3f);
            
        }
    }

    private void ActivateToBeContinued()
    {
        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null)
        {
            ui.ToBeContinued();
        }
        else
        {
            Debug.LogError("UIManager not found!");
        }
        
    }
}
