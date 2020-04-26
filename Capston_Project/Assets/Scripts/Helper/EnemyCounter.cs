using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] enemies;
    public Text enemyCountText;
    private int prevValue = 0;
    private int currentValue;
    public EnemyLootScript loot;
    void Start()
    {
        currentValue = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCountText.text = "Enemies : " + enemies.Length.ToString();

        Drop();
    }

    void Drop()
    {
        currentValue = enemies.Length;

        if(currentValue < prevValue)
        {
            loot.CalculateLoot();

        }
            prevValue = currentValue;
        return;
        
    }

}
