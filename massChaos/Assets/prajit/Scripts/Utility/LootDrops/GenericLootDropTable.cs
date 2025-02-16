﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class serves for assigning and picking loot drop items.
/// </summary>
public abstract class GenericLootDropTable<T, U> where T : GenericLootDropItem<U>
 {
	// List where we'll assign the items.
	[SerializeField]	
	public List<T> lootDropItems;

	// Sum of all weights of items.
	float probabilityTotalWeight;

	/// <summary>
	/// Calculates the percentage and asigns the probabilities how many times
	/// the items can be picked. Function used also to validate data when tweaking numbers in editor.
	/// </summary>	
	public void ValidateTable(){	

		// Prevent editor from "crying" when the item list is empty :)
		if(lootDropItems != null && lootDropItems.Count > 0){

			float currentProbabilityWeightMaximum = 0f;

			// Sets the weight ranges of the selected items.
			foreach(T lootDropItem in lootDropItems){

				if(lootDropItem.probabilityWeight < 0f){
					// Prevent usage of negative weight.
					Debug.Log("You can't have negative weight on an item. Reseting item's weight to 0.");
					lootDropItem.probabilityWeight =  0f;
				} else {
					lootDropItem.probabilityRangeFrom = currentProbabilityWeightMaximum;
					currentProbabilityWeightMaximum += lootDropItem.probabilityWeight;	
					lootDropItem.probabilityRangeTo = currentProbabilityWeightMaximum;						
				}

			}

			probabilityTotalWeight = currentProbabilityWeightMaximum;

			// Calculate percentage of item drop select rate.
			foreach(T lootDropItem in lootDropItems){
				lootDropItem.probabilityPercent = ((lootDropItem.probabilityWeight) / probabilityTotalWeight) * 100;
			}

		}		
		
	}

	/// <summary>
	/// Picks and returns the loot drop item based on it's probability.
	/// </summary>
	public T PickLootDropItem(){		

		float pickedNumber = Random.Range(0, probabilityTotalWeight);
        Debug.Log("first loop");
		// Find an item whose range contains pickedNumber
		foreach (T lootDropItem in lootDropItems)
		{
            Debug.Log("inside foreach");
			// If the picked number matches the item's range, return item
			if(pickedNumber > lootDropItem.probabilityRangeFrom && pickedNumber < lootDropItem.probabilityRangeTo){
                Debug.Log("if condition");
				return lootDropItem;
			}
		}	

		// If item wasn't picked... Notify programmer via console and return the first item from the list
		Debug.LogError("Item couldn't be picked... Be sure that all of your active loot drop tables have assigned at least one item!");
        return lootDropItems[0];
        //return null;
	}


}