﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimator : CharacterAnimator
{
    public WeaponAnimations[] weaponAnimations;
    Dictionary<Equipment, AnimationClip[]> weaponAnimationsDict;
    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentchanged += OnEquipmentChanged;

        weaponAnimationsDict = new Dictionary<Equipment, AnimationClip[]>();
        foreach(WeaponAnimations a in weaponAnimations)
        {
            weaponAnimationsDict.Add(a.weapon, a.clips);
        }
    }

    protected override void OnAttack()
    {
        /*if (currentWeaponAnimation != null)
        {
            int attackIndex = Random.Range(0, currentWeaponAnimation.numAnimations);
            animator.SetFloat("Attack Index", attackIndex);
            animator.SetFloat("Weapon Index", currentWeaponAnimation.weaponIndex);
        }
        */
        base.OnAttack(); //Not sure why this fixes it, but it does.

    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem.equipSlot == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(1, 1);
            if (weaponAnimationsDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAnimationsDict[newItem];
            }
        }
        else if (newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(1, 0);
            currentAttackAnimSet = defaultAttackAnimSet;
        }

        if(newItem != null && newItem.equipSlot == EquipmentSlot.Shield)
        {
            animator.SetLayerWeight(2, 1);
        }
        else if (newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.Shield)
        {
            animator.SetLayerWeight(2, 0);
        }
    }

    [System.Serializable]
    public struct WeaponAnimations
    {
        public Equipment weapon;
        public int weaponIndex;
        public AnimationClip[] clips;
    }
}
