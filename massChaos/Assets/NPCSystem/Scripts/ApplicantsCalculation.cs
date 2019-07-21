using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class ApplicantsCalculation : MonoBehaviour
{
    public float totalHappiness;
    public double totalNomads;
    public double totalFerrarium;
    public double totalFroots;
    public double totalMimax;
    public int baseCapacity = 2;
    public int numberOfNpcs;
    // Start is called before the first frame update
    void Start()
    {
        numberOfNpcs = baseCapacity * 2;

        Debug.Log("Happpy2 = " + Nomad.Prestige);

        totalHappiness = Nomad.HappinessIndex + Ferrarium.HappinessIndex + Mimax.HappinessIndex + Froots.HappinessIndex;

        float nomadCountDec = ((Nomad.happinessIndex / totalHappiness) * numberOfNpcs) / 100;

        float ferrariumCountDec = ((Nomad.happinessIndex / totalHappiness) * numberOfNpcs) / 100;

        float mimaxCountDec = ((Nomad.happinessIndex / totalHappiness) * numberOfNpcs) / 100;

        float frootsCountDec = ((Nomad.happinessIndex / totalHappiness) * numberOfNpcs) / 100;

        totalNomads = Math.Round(nomadCountDec);

        Debug.Log("Nomad Count = " +Nomad.HappinessIndex);

        totalFerrarium = Math.Round(ferrariumCountDec);

        Debug.Log("ferrarium Count = " + totalFerrarium);

        totalFroots = Math.Round(frootsCountDec);

        Debug.Log("totalFroots = " + totalFroots);

        totalMimax = Math.Round(mimaxCountDec);

        Debug.Log("totalMimax = " + totalMimax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
