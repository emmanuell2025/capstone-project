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
    private bool isOpened = false;


    

    void Start()
    {
        Animator lidAnimation = gameObject.GetComponent<Animator>(); // Get the lid animation
    }

    void OnTriggerEnter(Collider trigger) //If the player walks into the chest collider
    {
        radius = trigger.gameObject.name; //set the radius to the player
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

                if ((RaycastReturn == "Chest" || RaycastReturn == "Chest(Clone)") && Input.GetMouseButtonDown(1) && radius == "Player" && isOpened == false)
                {
                    lidAnimation.Play();
                    isOpened = true;
                    loot.calculateLoot();
                }
            }
        }
    }

}
