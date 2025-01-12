using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Skeleton skeleton;
    private Enemy enemy;
    
                                
    public override void Start()
    {
        base.Start();
        
        skeleton = GetComponent<Skeleton>();
        
    }

    public override void Die()
    {
        base.Die();

       
       
       
    }
}
