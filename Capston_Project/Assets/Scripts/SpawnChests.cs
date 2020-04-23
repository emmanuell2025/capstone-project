using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class SpawnChests : MonoBehaviour
{
    public GameObject[] chest = new GameObject[1];
          

    private int chestCount = 0;
    public int spawnAmount;

    //public GameObject dungeon = GameObject.Find("DungeonGenerator");


    public int xPosition;
    public int yPosition;
    public int zPosition;

    /*
         Min and max xyz positions are currently hard coded.
         This needs to be changed at some point.
    */

    int xMinimum = 0;
    int xMaximum = 200;
    int yMinimum = 0;
    int yMaximum = 2;
    int zMinimum = 0;
    int zMaximum = 200;


     
    void Start()
    {
        StartCoroutine(ChestDrop());
    }

    IEnumerator ChestDrop()
    {

        
        while (chestCount < spawnAmount)
        {
            int i = (Random.Range(1, 200)) % 3;
            
            xPosition = Random.Range(xMinimum, xMaximum);
            yPosition = Random.Range(yMinimum, yMaximum);
            zPosition = Random.Range(zMinimum, zMaximum);

            Instantiate(chest[i], new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            chestCount += 1;
        }

        xPosition = Random.Range(xMinimum, xMaximum);
        yPosition = Random.Range(yMinimum, yMaximum);
        zPosition = Random.Range(zMinimum, zMaximum);

        yield return new WaitForSeconds(0.1f);
        chestCount += 1;
    }
}
