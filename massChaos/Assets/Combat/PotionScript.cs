using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionScript : MonoBehaviour
{
    public Text potiontext;
    public int maxpotions;
     int currentpotions;
    // Start is called before the first frame update
    void Start()
    {
        currentpotions = maxpotions;
        
    }

    // Update is called once per frame
    void Update()
    {
        potiontext.text = "Potions:" + currentpotions;
        if (Input.GetButtonDown("Heal") && currentpotions > 0)
        {
            currentpotions-=1;
        }
    }
}
