using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Player player;
    
    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }

    public override void Die()
    {
        base.Die();
        player.Die();
        Invoke("YouDied", 1f);
        
    }

    public void YouDied()
    {
        LevelManager.instance.GameOver();
    }
}
