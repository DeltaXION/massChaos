using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AssignWeapon : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update
    public static GameObject g;
    void Start()
    {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.name == "WeaponSelect")
            {
                g = go;
            }
        }
        g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        string id = transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text.ToString();
        g.SetActive(true);
        NPCSystem.followerIdToUpdate = int.Parse((id));
       
    }
}
