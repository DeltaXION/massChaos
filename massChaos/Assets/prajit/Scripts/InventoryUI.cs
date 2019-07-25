using UnityEngine;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour {

	public Transform itemsParent;	// The parent object of all the items

    public Transform weaponsParent; //The parent object of all weapons

    public Transform equipmentParent;

    public Transform weaponBaseParent;

    public Transform primaryWeaponParent;



	public GameObject inventoryUI;	// The entire UI

	Inventory inventory;	// Our current inventory

    WeaponInventory weaponInventory; // our weapon inventory

    ElementalInventory elementalInventory; // player equipment 

    WeaponBaseInventory weaponBaseInventory;

    PrimaryWeaponInventory primaryWeaponInventory;

	InventorySlot[] slots;	// List of all the slots

    InventorySlot[] weaponSlots;  //list of weapon slotsa

    InventorySlot[] equipmentSlots;

    InventorySlot[] weaponBaseSlots;

    InventorySlot[] primarySlots;



	void Start () {
		inventory = Inventory.instance;
        weaponInventory = WeaponInventory.instance1;
        elementalInventory = ElementalInventory.instance;
        weaponBaseInventory = WeaponBaseInventory.instance;
        primaryWeaponInventory = PrimaryWeaponInventory.instance;

		inventory.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback
        weaponInventory.onItemChangedCallback += updateWeaponsUI;	// Subscribe to the onItemChanged callback
        elementalInventory.onItemChangedCallback += updateEquipmentUI;
        primaryWeaponInventory.onItemChangedCallback += updatePrimaryUI;
        weaponBaseInventory.onItemChangedCallback += updateBaseUI;


      

        // Populate our slots array
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		weaponSlots = weaponsParent.GetComponentsInChildren<InventorySlot>();
        equipmentSlots = equipmentParent.GetComponentsInChildren<InventorySlot>();
        weaponBaseSlots = weaponBaseParent.GetComponentsInChildren<InventorySlot>();
        primarySlots = primaryWeaponParent.GetComponentsInChildren<InventorySlot>();



    }
	
	void Update () {
		// Check to see if we should open/close the inventory
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}

	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	void UpdateUI ()
	{
        Debug.Log(slots.Length);
		// Loop through all the slots
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)	// If there is an item to add
			{
				slots[i].AddItem(inventory.items[i]);	// Add it
			} else
			{
				// Otherwise clear the slot
				slots[i].ClearSlot();
			}
		}
	}

    void updateWeaponsUI()
    {
        // Loop through all the slots
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (i < weaponInventory.items.Count)  // If there is an item to add
            {
                weaponSlots[i].AddItem(weaponInventory.items[i]);   // Add it
            }
            else
            {
                // Otherwise clear the slot
                weaponSlots[i].ClearSlot();
            }
        }
    }

    void updateEquipmentUI()
    {
        // Loop through all the slots
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (i < elementalInventory.items.Count)  // If there is an item to add
            {
                equipmentSlots[i].AddItem(elementalInventory.items[i]);   // Add it
            }
            else
            {
                // Otherwise clear the slot
                equipmentSlots[i].ClearSlot();
            }
        }
    }

        void updateBaseUI()
        {
            // Loop through all the slots
            for (int i = 0; i < weaponBaseSlots.Length; i++)
            {
                if (i < weaponBaseInventory.items.Count)  // If there is an item to add
                {
                    weaponBaseSlots[i].AddItem(weaponBaseInventory.items[i]);   // Add it
                }
                else
                {
                    // Otherwise clear the slot
                    weaponBaseSlots[i].ClearSlot();
                }
            }
        }


    void updatePrimaryUI()
    {
        // Loop through all the slots
        for (int i = 0; i < primarySlots.Length; i++)
        {
            if (i < primaryWeaponInventory.items.Count)  // If there is an item to add
            {
                primarySlots[i].AddItem(primaryWeaponInventory.items[i]);   // Add it
            }
            else
            {
                // Otherwise clear the slot
                primarySlots[i].ClearSlot();
            }
        }
    }
}
