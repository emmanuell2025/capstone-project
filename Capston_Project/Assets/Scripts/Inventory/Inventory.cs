using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than on instance of Inventory!");
            return;
        }

        instance = this;
    }

    #endregion

    //an delegate can be given other methods
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public GameObject itemDescriptionPanel;
    public Text itemNameText;
    public Text itemDescriptionText;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room in Inventory.");
                return false;
            }
            items.Add(item);

           if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }                
        }

        return true;        
    }


    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
