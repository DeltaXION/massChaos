using UnityEngine;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour {

	public Transform itemsParent;	// The parent object of all the items

    public Transform weaponsParent; //The parent object of all weapons

    public Transform equipmentParent;

	public GameObject inventoryUI;	// The entire UI

	Inventory inventory;	// Our current inventory

    WeaponInventory weaponInventory; // our weapon inventory

    ElementalInventory elementalInventory; // player equipment 

	InventorySlot[] slots;	// List of all the slots

    InventorySlot[] weaponSlots;  //list of weapon slotsa

    InventorySlot[] equipmentSlots;

	void Start () {
		inventory = Inventory.instance;
        weaponInventory = WeaponInventory.instance1;
        elementalInventory = ElementalInventory.instance;
		inventory.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback
        weaponInventory.onItemChangedCallback += updateWeaponsUI;	// Subscribe to the onItemChanged callback
        elementalInventory.onItemChangedCallback += updateEquipmentUI;

		// Populate our slots array
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		weaponSlots = weaponsParent.GetComponentsInChildren<InventorySlot>();
		equipmentSlots = equipmentParent.GetComponentsInChildren<InventorySlot>();
       
  
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
}
