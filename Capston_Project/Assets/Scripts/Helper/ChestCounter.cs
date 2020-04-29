using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestCounter : MonoBehaviour
{
    GameObject[] chests;
    private int prevValue = 0;
    private int currentValue;
    public LootScript loot;
    void Start()
    {
        currentValue = chests.Length;
    }

    // Update is called once per frame
    void Update()
    {
        chests = GameObject.FindGameObjectsWithTag("Chest");
        Drop();
    }

    void Drop()
    {
        currentValue = chests.Length;

        if(currentValue < prevValue)
        {

            
            loot.CalculateLoot();

        }
            prevValue = currentValue;
        return;
        
    }

}
