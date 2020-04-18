using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public EnemyLootScript loot;
    public override void Die()
    {
        
        base.Die();
        //Death Animation
  
        loot.calculateLoot();
        Destroy(gameObject);


    }


}
