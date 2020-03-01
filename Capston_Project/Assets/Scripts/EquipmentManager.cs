using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region singleton
    public static EquipmentManager instance;

    void awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentchanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentchanged onEquipmentchanged;

    Inventory inventory;

    void start() {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

    }

    public void Equip(Equipment newItem) {

        int slotIndex =(int)newItem.equipSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null) {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentchanged != null) {
            onEquipmentchanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }


    public void Unequip(int slotIndex)
    {

        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            currentEquipment[slotIndex] = null;

            if (onEquipmentchanged != null)
            {
                onEquipmentchanged.Invoke(null, oldItem);
            }

        }
    }

        public void UnequipAll() {

        for (int i = 0; i < currentEquipment.Length; i++) {
            Unequip(i);
        }

    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}
