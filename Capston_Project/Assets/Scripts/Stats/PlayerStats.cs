﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public AudioClip painSound;
    public AudioSource headSource;
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentchanged += OnEquipmentChanged;
    }

    // Update is called once per frame
    void OnEquipmentChanged ( Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        headSource.PlayOneShot(painSound);
        PlayerManager.instance.KillPlayer();

    }

}
