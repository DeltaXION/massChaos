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

  //  ItemType itemType = ItemType.Elemental;


   

    public delegate void OnEquipmentChanged(Item newItem, Item oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    WeaponInventory weaponInventory;

    ElementalInventory elementalInventory;

    WeaponBaseInventory weaponBaseInventory;

    PrimaryWeaponInventory primaryWeaponInventory;

    private void Start()
    {
        weaponInventory = WeaponInventory.instance1;

        elementalInventory = ElementalInventory.instance;

        weaponBaseInventory = WeaponBaseInventory.instance;

        primaryWeaponInventory = PrimaryWeaponInventory.instance;

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

    public void EquipWeapon(Item newItem)
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
            weaponBaseInventory.Add(newItem);
        }
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Item oldItem = currentEquipment[slotIndex];
            elementalInventory.Add(oldItem);

            if(onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            currentEquipment[slotIndex] = null;
        }
    }

    public void EquipPrimary(Item newItem)
    {
        {


            int slotIndex = (int)newItem.itemtype;


            Item oldItem = null;

            if (currentEquipment[slotIndex] != null)
            {
                oldItem = currentEquipment[slotIndex];
                weaponInventory.Add(oldItem);
            }

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(newItem, oldItem);
            }

            Debug.Log("slotIndex" + slotIndex);
            currentEquipment[slotIndex] = newItem;
            primaryWeaponInventory.Add(newItem);
        }
    }

    public void TransferItems()
    {
        for(int i = 0; ;i++)
        {
            Unequip(i);
        }
    }

}