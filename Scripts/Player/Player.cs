using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public bool isBusy { get; private set; }
    [SerializeField] protected Transform spikesCheck;
    [SerializeField] protected float spikesCheckDist;
    private float damageTimer = 0f;
    public int damagePerSecond = 10;
   

    CharacterStats playerStats;
  
    #region Player_info
    [Header("Move info")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Dash info")]
    [SerializeField] private float dashCd;
    private float dashTimer;
    public float dashSpeed;
    public float dashDur;
    public float dashDir { get; private set; }
    #endregion




    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    public PlayerDeathState deathState { get; private set; }


    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "isMoving");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "isDashing");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "isWallSliding");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");
        attackState = new PlayerAttackState(this, stateMachine, "isAttacking");
        deathState = new PlayerDeathState(this, stateMachine, "isDead");






    }

    protected override void Start()
    {

        base.Start();
        playerStats = GetComponent<CharacterStats>();
        stateMachine.Initalize(idleState); 
    }

    private void OnDrawSpikesGizmos()
    {
        Gizmos.DrawLine(spikesCheck.position, new Vector3(spikesCheck.position.x, spikesCheck.position.y - spikesCheckDist));
    }

    protected override void Update()
    {

        base.Update();
        stateMachine.currentState.Update();

        
        SpikesDamage();

       
        DashInput();
    }

  

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    

    private void SpikesDamage()
    {
        if (IsSpikesDetected())
        {
            if (damageTimer <= 0f && stats.currentHealth > 0)
            {
                stats.TakeDamage(10);
                hitMaterial.StartCoroutine("ChangeMaterial");
                damageTimer = 1f;
            }
            else
            {
                damageTimer -= Time.deltaTime;
            }
        }
        else
        {
            damageTimer = 0f;
        }

    }
    public void DashInput()
    {
        if (IsWallDetected())
            return;

        dashTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer < 0)
        {
            dashTimer = dashCd;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facinDir;

            stateMachine.ChangeState(dashState);
        }




    }

    public virtual bool IsSpikesDetected() => Physics2D.Raycast(spikesCheck.position, Vector2.down, spikesCheckDist, whatIsSpikes);






    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deathState);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

}



