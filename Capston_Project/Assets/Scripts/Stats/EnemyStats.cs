using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public EnemyLootScript loot;
    private bool isCalculated = false;
    public override void Die()
    {   
        base.Die();
        //Death Animation
        if (!isCalculated)
        {
            loot.CalculateLoot();
            isCalculated = true;
        }
        if (isCalculated == true)
        {
            Destroy(gameObject);
            isCalculated = false;
        }

    }


}
