using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyFollowerSlot : MonoBehaviour
{
    public string FollowerName, FollowerRace, FollowerClass, FollowerSecondaryWeapon, FollowerPrimaryWeapon, FollowerStatus;
    
    void Start()
    {
        FollowerName = "Jarp;d";
        FollowerRace = "NOMAD";
            FollowerClass = FollowerSecondaryWeapon = FollowerPrimaryWeapon = FollowerStatus = " ";
    }
}
