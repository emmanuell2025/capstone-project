using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public GameObject chest;
    public Animation lidAnimation;
    public LootScript loot;
    Ray ray;
    RaycastHit hit;
    private string RaycastReturn;
    private string radius;


    

    void Start()
    {
        Animator lidAnimation = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider trigger)
    {
        radius = trigger.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                RaycastReturn = hit.collider.gameObject.name;
                
                if(RaycastReturn == "Chest" && Input.GetMouseButtonDown(1) && radius == "Player")
                {
                    lidAnimation.Play();
                    loot.calculateLoot();
                }
            }
        }
    }

}
