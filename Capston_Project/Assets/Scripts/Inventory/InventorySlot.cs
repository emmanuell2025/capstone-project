using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public GameObject player;
    public GameObject pickUp;

    Item item;

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
}
