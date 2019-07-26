using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AddFoodPlants : MonoBehaviour
{
    public int plantFoodValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void OnSelect(BaseEventData eventData)
    {
        ResourceManager.addFood(90);
        Debug.Log("hi");
    }*/
    public void OnMouseDown()
    {
        ResourceManager.addFood(plantFoodValue);
    }
}
