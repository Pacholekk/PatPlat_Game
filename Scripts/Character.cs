using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Collision info")]
    public Transform attackCheck;
    public float attackCheckDist;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDist;
 
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDist;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected LayerMask whatIsEnemy;
    [SerializeField] protected LayerMask whatIsSpikes;
    [SerializeField] private Vector2 knockbackDir;
    protected bool isKnocked;


    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public OnHitMaterial hitMaterial { get; private set; }
    public CharacterStats stats { get; private set; }
    public CapsuleCollider2D capsuleCollider { get; private set; }
    

    public int facinDir { get; private set; } = 1;

    public int health { get; private set; }
    public int attackDamage { get; private set; }
    
    protected bool facinRight = true;
    
    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        hitMaterial = GetComponent<OnHitMaterial>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        
    }

    protected virtual void Update()
    {

    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDist));
      
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDist * facinDir, wallCheck.position.y));
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckDist);
    }

    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDist, whatIsGround);
    

    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facinDir, wallCheckDist, whatIsGround);

    



    public virtual void Flip()
    {
        facinDir = facinDir * -1;
        facinRight = !facinRight;
        transform.Rotate(0, 180, 0);
      
        
    }



    public virtual void FlipControler(float _x)
    {
        if (_x > 0 && !facinRight)
            Flip();
        else if (_x < 0 && facinRight)
            Flip();
    }

    public virtual void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isKnocked)
            return;


        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipControler(_xVelocity);

    }

    public virtual void OnDamageHit()
    {
        if (stats.currentHealth > 0)
        {
            hitMaterial.StartCoroutine("ChangeMaterial");
            StartCoroutine("KnockBack");
        }

    }


   public virtual IEnumerator KnockBack()
    {
        isKnocked = true;
        rb.velocity = new Vector2(knockbackDir.x * -facinDir, knockbackDir.y);

        yield return new WaitForSeconds(.3f);
        rb.velocity = new Vector2(0, 0);
        isKnocked = false;
    }

    public virtual void Die()
    {
       
    }
}
