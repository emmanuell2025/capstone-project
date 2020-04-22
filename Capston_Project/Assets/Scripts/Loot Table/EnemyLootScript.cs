using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootScript : MonoBehaviour
{
    [System.Serializable]
    public class DropItems
    {
        public string itemName;
        public GameObject item;
        public int dropRarity;
    }

    public List<DropItems> LootTable = new List<DropItems>(); //Allows you to add as many items to the loot table as you want.
    public int dropChance;
    public Transform player;
    public float spawnDistance;
    public Vector2 xRange;
    public Vector2 yRange;

    public void CalculateLoot()
    {
        int calcDropChance = Random.Range(0, 101); //Calculates if you get loot at all.

        if(calcDropChance > dropChance) //If the random loot is greater than the drop chance, you don't get anything.
        {
            Debug.Log("No Loot!");
            return;
        }

        if(calcDropChance <= dropChance)
        {
            int itemWeight = 0;

            for(int i = 0; i < LootTable.Count; i++) //Calculates the Rarity of all items
            {
                itemWeight += LootTable[i].dropRarity; //Stores all of the rarities from dropRarity into itemWeight
            }
            Debug.Log("Item Weight =" + itemWeight);


            int randomValue = Random.Range(0, itemWeight); //Chooses a random value between 0 and the total value stored in itemWeight
            Vector3 spawnPos = player.position; // Gets the players position
            spawnPos.x += Random.Range(xRange.x, xRange.y); //Random position on x
            spawnPos.y += Random.Range(yRange.x, yRange.y); //Random position on y
            spawnPos.z += spawnDistance; //How far away the items will be from player

            for (int j = 0; j < LootTable.Count; j++)
            {
                if(randomValue <= LootTable[j].dropRarity) //Checks if the number randomly chosen from randomValue is less than or equal to a rarity in the loot table
                {
                    Instantiate(LootTable[j].item, spawnPos, Quaternion.identity); //Spawns the chosen item in front of the player
                    return;
                }
                randomValue -= LootTable[j].dropRarity; //If the rarity isn't found, subtract the random value from the current rarity.
                Debug.Log("Random Value decreased" + randomValue);
            }
        }
    }
}
