using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public AudioClip painSound;
    public AudioSource headSource;

    public override void Die()
    {
        // headSource.PlayOneShot(painSound);
        AudioSource.PlayClipAtPoint(painSound, this.gameObject.transform.position);
        base.Die();
        //Death Animation
        Destroy(gameObject);


    }


}
