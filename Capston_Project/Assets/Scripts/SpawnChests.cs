using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;


public class SpawnChests : MonoBehaviour
{
    public GameObject[] chest = new GameObject[1];
         

    private int chestCount = 0;
    public int amount = 100;

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
    private bool isSpawned = false;


     
    void Start()
    {
        //StartCoroutine(ChestDrop());
    }

    void Update()
    {
        if (!isSpawned)
        {
            StartCoroutine(ChestDrop());
            isSpawned = true;
        }

    }

    IEnumerator ChestDrop()
    {

        
        while (chestCount < amount)
        {
            int i = (Random.Range(1, 200)) % 3;
            /*
            xPosition = Random.Range(xMinimum, xMaximum);
            yPosition = Random.Range(yMinimum, yMaximum);
            zPosition = Random.Range(zMinimum, zMaximum);
            */
            Vector3 aPoint = GetRandomLocations();
            Instantiate(chest[i], new Vector3(aPoint.x,aPoint.y, aPoint.z), Quaternion.identity);    //xPosition, yPosition, zPosition), Quaternion.identity
            yield return new WaitForSeconds(0.1f);
            chestCount += 1;
        }

        Vector3 bossSpot = GetRandomLocations();
        /*
        xPosition = Random.Range(xMinimum, xMaximum);
        yPosition = Random.Range(yMinimum, yMaximum);
        zPosition = Random.Range(zMinimum, zMaximum);
        */
        yield return new WaitForSeconds(0.1f);
        chestCount += 1;
    }

    Vector3 GetRandomLocations()
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
