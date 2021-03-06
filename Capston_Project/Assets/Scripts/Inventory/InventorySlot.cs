﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/*
   Dont use OnMouseOver for UI elements,
   use IPointerEnterHandler, which requires
   UnityEngine.EventSystems, IPointerEnterHandler,
   and IPointerExitHandler to be included.
*/

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public Button removeButton;
    public GameObject player;
    public GameObject pickUp;
    public bool mouseIsOver = false;//Is the cursor over the inventory slot?
    public Item item;



    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        if(item.itemPickup != null)
        {
            player = GameObject.Find("Player");
            pickUp = item.itemPickup;
            Instantiate(pickUp, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
        }
        Inventory.instance.Remove(item);

    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();

        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseIsOver = true;
        //Debug.Log("Mouse is now over Inventory Slot.");
        if(item != null)
        {
            Inventory.instance.itemNameText.text = item.itemName;
            Inventory.instance.itemDescriptionText.text = item.GetItemDescription();
            Inventory.instance.itemDescriptionPanel.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseIsOver = false;
        Inventory.instance.itemDescriptionPanel.SetActive(false);
        //Debug.Log("Mouse is no longer over Inventory Slot.");
    }
}
