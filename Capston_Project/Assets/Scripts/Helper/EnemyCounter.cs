using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] Piggeh;
    GameObject[] Slime;
    GameObject[] Big;

    public Text enemyCountText;
    private int prevValue = 0;
    private int currentValue;
    public EnemyLootScript loot;
    void Start()
    {
        currentValue = Piggeh.Length;
        currentValue += Slime.Length;
        currentValue += Big.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Piggeh = GameObject.FindGameObjectsWithTag("Enemy");
        Slime = GameObject.FindGameObjectsWithTag("Slime");
        Big = GameObject.FindGameObjectsWithTag("Big");

        enemyCountText.text = "Little Piggeh : " + Piggeh.Length.ToString() + "\n";
        enemyCountText.text += "Slime : " + Slime.Length.ToString() + "\n";
        enemyCountText.text += "Big Piggeh : " + Big.Length.ToString();




        Drop();
    }

    void Drop()
    {
      currentValue = Piggeh.Length;
      currentValue += Slime.Length;
      currentValue += Big.Length;

        if(currentValue < prevValue)
        {
            loot.CalculateLoot();
        }
            prevValue = currentValue;
        return;

    }

}
