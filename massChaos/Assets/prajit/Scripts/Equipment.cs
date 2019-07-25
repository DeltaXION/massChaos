using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Weapon")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;

    public override void Use()
    {
        base.Use();

        //EquipmentManager.instance.Equip(this);
        //RemoveFromWeaponInventory();
    }
}

public enum EquipmentSlot { Elemental, Mage, Combat };