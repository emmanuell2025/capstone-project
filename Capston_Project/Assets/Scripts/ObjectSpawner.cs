using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject item;
    public int numItemsToSpawn;
    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;
    void Start()
    {
        for (int i = 0; i < numItemsToSpawn; i++)
        {
            SpreadItems();
        }
        
    }


    void SpreadItems()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        
        GameObject clone = Instantiate(item, randPosition, Quaternion.identity);

        
    }


}
