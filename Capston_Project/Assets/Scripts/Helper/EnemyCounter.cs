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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Piggeh = GameObject.FindGameObjectsWithTag("Enemy");
        Slime = GameObject.FindGameObjectsWithTag("Slime");
        Big = GameObject.FindGameObjectsWithTag("Big");

        enemyCountText.text = "Piggeh : " + Piggeh.Length.ToString() + "\n";
        enemyCountText.text += "Slime : " + Slime.Length.ToString() + "\n";
        enemyCountText.text += "Big : " + Big.Length.ToString();




    }
}
