using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class RandomPointOnNavMesh : MonoBehaviour
{
    public float range = 10.0f;
    public GameObject item;
    public int amount;
    private Vector3 point;
   

    void Start()
    {
        RandomPoint(transform.position, range, out point);

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                GameObject clone = Instantiate(item, randomPoint, Quaternion.identity);
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }



}
