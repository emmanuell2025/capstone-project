using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;


public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemy = new GameObject[3];
    
    public GameObject theBoss;       

    private int enemyCount = 0;
    public int spawnAmount = 100;

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
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {

        
        while (enemyCount < spawnAmount)
        {
            int i = (Random.Range(1, 200)) % 3;
            /*
            xPosition = Random.Range(xMinimum, xMaximum);
            yPosition = Random.Range(yMinimum, yMaximum);
            zPosition = Random.Range(zMinimum, zMaximum);
            */
            Vector3 aPoint = GetRandomLocation();
            Instantiate(enemy[i], new Vector3(aPoint.x,aPoint.y, aPoint.z), Quaternion.identity);    //xPosition, yPosition, zPosition), Quaternion.identity
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }

        Vector3 bossSpot = GetRandomLocation();
        /*
        xPosition = Random.Range(xMinimum, xMaximum);
        yPosition = Random.Range(yMinimum, yMaximum);
        zPosition = Random.Range(zMinimum, zMaximum);
        */
        Instantiate(theBoss, new Vector3(bossSpot.x, bossSpot.y, bossSpot.z), Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        enemyCount += 1;
    }

    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }
}
