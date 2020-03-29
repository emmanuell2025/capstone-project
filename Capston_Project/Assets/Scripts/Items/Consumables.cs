using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Consumable")]
public class Consumables : Item 
{
    public int healAmount = 0;
    public const int ZERO = 0;
    public override void Use()
    {
        base.Use();
        Debug.Log(name + " has been consumed.");
        GameObject player = GameObject.Find("Player");
        CharacterStats playersHealth = player.GetComponent<CharacterStats>();        
        playersHealth.Heal(healAmount); // Heal the player        
        playersHealth.TakeDamage(ZERO);//This is here only to update the HealthBar.

    }
}
