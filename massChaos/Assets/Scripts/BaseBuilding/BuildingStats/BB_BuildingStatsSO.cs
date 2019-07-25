using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building_Stats")]
public class BB_BuildingStatsSO : ScriptableObject
{
    [SerializeField] Sprite BuildingSprite;
    [SerializeField] int capacity;
    [SerializeField] string currentLevel, NPC_LivingName, RepairNeeded, Message;

    [Header("Resources Required")]
    [SerializeField] int wood;
    [SerializeField] int food;
    [SerializeField] int iron;
    [SerializeField] int gold;

    public Sprite GetBuildingSprite()
    {
        return BuildingSprite;
    }

    public int getCapacity()
    {
        return capacity;
    }

    public string CurrentLevel()
    {
        return currentLevel;
    }

    public string npc_LivingName()
    {
        return NPC_LivingName;
    }

    public string repairNeeded()
    {
        return RepairNeeded;
    }

    public string message()
    {
        return Message;
    }

    public string resourcesRequired()
    {
        string RR = "Wood " + wood.ToString() + "\n" + "Iron " + iron.ToString() + "\n" + "Gold " + gold.ToString();
        return RR;
    }

}
