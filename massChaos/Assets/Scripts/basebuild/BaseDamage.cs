using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamage : MonoBehaviour
{
    public int maxOutBuild = 10;
    public int buildingID;
    public string jobType;
    public static int destroyedbuilds;
    public static int UpgradedWorkshop;
    public static bool desBarracks;
    static NPCSystem NPC;
    public static BaseHealth baseHlth;
    public static double n;
    public static float num;
    public static double n1;
    public static float num1;
    public static string[] arr = new string[] { "Barracks", "Market", "Farm", "Workshop" };
    public static string tags;

  

    public static void WeatherDamage()
    {
        //NPC = new NPCSystem();
        baseHlth = new BaseHealth();
        foreach (var o in NPCSystem.followers)
        {
            //if (o.Type == "Nomad")
            if (o.Status == "Barracks")
            {
                if (o.Type != "Nomad")

                {
                    if (GameObject.FindGameObjectsWithTag("Barracks").Length > 0)
                    {
                        //if (BB_GlobalStats.UpgradedWorkshop < 2)
                        {
                            GameObject barracks = GameObject.FindWithTag("Barracks");
                            Destroy(barracks);
                            destroyedbuilds++;
                            //destroyedbuilds = destroyedbuilds + 1;
                            NPCSystem.removeFollower(o.Id);
                            baseHlth.BaseHealthCalc();
                        }
                    }

                }

            }

            //if (o.Type == "Ferrarium")
            if (o.Status == "Market")
            {
                if (o.Type != "Ferrarium")

                {
                    if (GameObject.FindGameObjectsWithTag("Market").Length > 0)
                    {

                        //if (BB_GlobalStats.UpgradedMarket < 2)
                        {
                            GameObject market = GameObject.FindWithTag("Market");
                            Destroy(market);
                            destroyedbuilds++;
                            NPCSystem.removeFollower(o.Id);
                            baseHlth.BaseHealthCalc();
                        }

                    }
                }

            }
            //if (o.Type == "Froot")
            if (o.Status == "Farm")
            {
                if (o.Type != "Froot")

                {
                    if (GameObject.FindGameObjectsWithTag("Farm").Length > 0)
                    {

                        //if (BB_GlobalStats.UpgradedFarms < 2)
                        {
                            GameObject farm = GameObject.FindWithTag("Farm");
                            Destroy(farm);
                            destroyedbuilds++;
                            NPCSystem.removeFollower(o.Id);
                            baseHlth.BaseHealthCalc();
                        }

                    }
                }

            }

            //if (o.Type == "Mimax")
            if (o.Status == "Workshop")
            {
                if (o.Type != "Mimax")

                {
                    if (GameObject.FindGameObjectsWithTag("Workshop").Length > 0)
                    {

                        //if (BB_GlobalStats.upgradeBarracks < 2)
                        {
                            GameObject workshop = GameObject.FindWithTag("Workshop");
                            Destroy(workshop);
                            destroyedbuilds++;
                            NPCSystem.removeFollower(o.Id);
                            baseHlth.BaseHealthCalc();
                        }
                    }

                }

            }



            if (GameObject.FindGameObjectsWithTag("House").Length > 0)
            {

                if (o.Status == "House")
                {
                    if (o.Status != "idle")
                    {
                        //if (BB_GlobalStats.UpgradedHouses < 2)
                        {
                            GameObject house = GameObject.FindWithTag("House");
                            Destroy(house);
                            destroyedbuilds++;
                            NPCSystem.removeFollower(o.Id);
                            baseHlth.BaseHealthCalc();
                        }

                    }
                }


            }






        }

    }
    public static void MiniBDamage()
    {
        NPC = new NPCSystem();
        baseHlth = new BaseHealth();
        foreach (var o in NPCSystem.followers)
        {

            if (BB_BasicControls.OutpBuilt != 10)
            {
                if (GameObject.FindGameObjectsWithTag("House").Length > 0)
                {

                    num = (BB_BasicControls.houseBuilt / 2);
                    n = Mathf.Round(num);

                    if (o.Status == "House")
                    {
                        if (n > 0)
                        {
                            GameObject house = GameObject.FindWithTag("House");
                            Destroy(house);
                            destroyedbuilds++;
                            n--;
                            NPCSystem.removeFollower(o.Id);
                            baseHlth.BaseHealthCalc();

                        }


                    }
                }
                if (GameObject.FindGameObjectsWithTag("Outpost").Length > 0)
                {

                    num1 = (BB_BasicControls.OutpBuilt / 2);
                    n1 = Mathf.Round(num1);
                    if (o.Status == "Outpost")
                    {
                        if (n1 > 0)
                        {
                            GameObject outpost = GameObject.FindWithTag("Outpost");
                            Destroy(outpost);
                            destroyedbuilds++;
                            n1--;
                            NPCSystem.removeFollower(o.Id);
                            baseHlth.BaseHealthCalc();
                        }

                    }
                }
                tags = arr[Random.Range(0, 1)];
                if (o.Status == tags)
                {
                    if (GameObject.FindGameObjectsWithTag(tags).Length > 0)
                    {
                        GameObject building = GameObject.FindWithTag(tags);
                        Destroy(building);
                        destroyedbuilds++;
                        NPCSystem.removeFollower(o.Id);
                        baseHlth.BaseHealthCalc();

                    }
                }


            }
        }

    }
}
