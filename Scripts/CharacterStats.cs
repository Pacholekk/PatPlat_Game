using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    

    public System.Action healthChange;

    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void Update()
    {
        

    }

   

    public virtual void TakeDamage(int _damage)
    {

        DecreseHealth(_damage);
       
        if (currentHealth <= 0 )
            Die();

    }
    protected virtual void DecreseHealth(int _damage)
    {
        currentHealth -= _damage;

        if (healthChange != null)
            healthChange();

    }

    public virtual void Die()
    {
       

    }

   

}
