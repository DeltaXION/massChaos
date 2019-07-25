using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseHealth : MonoBehaviour
{
    public static float baseHealth;
    public Image baseH;


    public void BaseHealthCalc()
    {
        float MaxOutpostHealth = 60f;
        float MaxOutposts = 10;

        //float CurrentOutpost = BB_BasicControls.OutpBuilt;
        float CurrentOutpost = 5;

        float CurrentOutPostHealth = (CurrentOutpost * MaxOutpostHealth) / (MaxOutposts);

        float MaxFollowerHealth = 40f;
        float MaxFollowers = 20;

        //float CurrentFollowercount = NPCSystem.followers.Count;
        float CurrentFollowercount = 6;
        float CurrentFollowerHealth = (CurrentFollowercount * MaxFollowerHealth) / (MaxFollowers);

        baseHealth = CurrentOutPostHealth + CurrentFollowerHealth;

        baseH.fillAmount = baseHealth/100;
    }



   
}
