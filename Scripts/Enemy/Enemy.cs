using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    [SerializeField] protected LayerMask whatIsPlayer;
    [SerializeField] private float playerCheckDist;

    [Header("Movve info")]
    public float moveSpeed;
    public float idleTime;
    public float attackMoveSpeed;
    public float attackCooldown;
    public float lastTimeAttacked;
    public float attackDistance;
    public float agresiveTime;





    public EnemyStateMachine stateMachine { get; private set; }
    public string lastAnim { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    public virtual void TakeLastAnime(string _animBoolName)
    {
        lastAnim = _animBoolName;
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        

    }
    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facinDir, playerCheckDist, whatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facinDir, transform.position.y));
    }
}
