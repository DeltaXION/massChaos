using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{


    new public string name = "New Item";    // Name of the item
    public Sprite icon = null;              // Item icon
    public bool isDefaultItem = false;      // Is the item default wear?
    public GameObject prefab = null;

    public ItemType itemtype;


    // Called when the item is pressed in the inventory
    public virtual void Use()
    {
        // Use the item
        // Something might happen

        Debug.Log("Using " + name);

        switch (itemtype)
        {
            case ItemType.item:
                EquipmentManager.instance.Equip(this);
                RemoveFromInventory();
                break;
            case ItemType.Weapon:
                EquipmentManager.instance.EquipWeapon(this);
                RemoveFromWeaponInventory();
                break;

        }

    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public void RemoveFromWeaponInventory()
    {
        WeaponInventory.instance1.Remove(this);
    }

    public virtual void UsePrimary()
    {
        Debug.Log("using primary");
        EquipmentManager.instance.EquipPrimary(this);
        RemoveFromWeaponInventory();
    }

}


public enum ItemType {Weapon, item }; 