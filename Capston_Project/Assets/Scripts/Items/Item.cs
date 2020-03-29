﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public GameObject itemPickup;
        
    public virtual void Use()
    {
        Debug.Log("Using " + name);
        
    }
    public void RemoveFromInventory() {

        Inventory.instance.Remove(this);
    }
}
