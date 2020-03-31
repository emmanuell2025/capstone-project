using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;
    

    public int armorModifier;
    public int damageModifier;      

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);

        RemoveFromInventory();

    }

    public override string GetItemDescription()
    {
        string description = "";
        if (damageModifier > 0)
        {
            description = description + "Boosts Attack by " + damageModifier + " points.\n";            
        }
        if (armorModifier > 0)
        {
            description = description + "Boosts Defense by " +armorModifier + " points.\n";
        }
        return description;
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
public enum EquipmentMeshRegion { Legs, Arms, Torso }; //controls body blend shapes.