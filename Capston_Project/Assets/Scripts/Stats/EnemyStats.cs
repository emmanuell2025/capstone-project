using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public EnemyLootScript loot;
    private bool isDestroyed = false;
    public override void Die()
    {   
        base.Die();
        //Death Animation
        
        if (!isDestroyed) //if isDestroyed is false, Destroy the object and set isDestroyed to true
        {
            Destroy(gameObject);
            isDestroyed = true;
        }

        if(isDestroyed = true) //if isDestroyed is true, run loot method and set it back to false so it can continue dropping loot for other enemies
        {
            loot.calculateLoot();
            isDestroyed = false;
        }
    }


}
