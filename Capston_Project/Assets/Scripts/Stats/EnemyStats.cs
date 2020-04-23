using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public AudioClip painSound;
    public AudioSource headSource;
    public EnemyLootScript loot;
    private bool isCalculated = false;

    public override void Die()
    {
        headSource.PlayOneShot(painSound);
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
        }


    }


}
