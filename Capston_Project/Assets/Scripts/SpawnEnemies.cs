using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPosition;
    public int yPosition;
    public int zPosition;

    /*
         Min and max xyz positions are currently hard coded.
         This needs to be changed at some point.
    */

    int xMinimum = 15;
    int xMaximum = 35;
    int yMinimum = 4;
    int yMaximum = 8;
    int zMinimum = 15;
    int zMaximum = 35;


    public int enemyCount; //Default will be ZERO;
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPosition = Random.Range(xMinimum, xMaximum);
            yPosition = Random.Range(yMinimum, yMaximum);
            zPosition = Random.Range(zMinimum, zMaximum);

            Instantiate(theEnemy, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
