using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singelton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    Item[] currentEquipment;

    Item item;

    ItemType itemType = ItemType.Elemental;


   

    public delegate void OnEquipmentChanged(Item newItem, Item oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    WeaponInventory weaponInventory;

    ElementalInventory elementalInventory;

    private void Start()
    {
        weaponInventory = WeaponInventory.instance1;

        elementalInventory = ElementalInventory.instance;

        int numSlots = elementalInventory.space;
        currentEquipment = new Item[numSlots];
        Debug.Log("numslots" + numSlots);
    }

    public void Equip(Item newItem)
    {
        {


            int slotIndex = (int)newItem.itemtype;

            Item oldItem = null;

            //if (currentEquipment[slotIndex] != null)
            //{
            //    oldItem = currentEquipment[slotIndex];
            //    weaponInventory.Add(oldItem);
            //}

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(newItem, oldItem);
            }

            Debug.Log("slotIndex" + slotIndex);
            currentEquipment[slotIndex] = newItem;
            elementalInventory.Add(newItem);
        }        
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Item oldItem = currentEquipment[slotIndex];
            weaponInventory.Add(oldItem);

            if(onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            currentEquipment[slotIndex] = null;
        }
    }

    public void sortItems(int slotIndex)
    {
        Item oldItem = currentEquipment[slotIndex];
        switch(itemType)
        {
            case ItemType.Elemental:
                elementalInventory.Add(oldItem);
                break;

            case ItemType.Mage:
                break;

            case ItemType.Combat:
                break;

            case ItemType.Recipe:
                break;


        }
    }

}
