using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerLeaving : MonoBehaviour
{

	private float CurrentFrootHappiness;
    private float CurrentFerroHappiness;
    private float CurrentNomadHappiness;
    private float CurrentMimaxHappiness;

	private int FrootFollowerID;

    

	
    // Start is called before the first frame update
    void Start()
    {
		
    }

	private IEnumerator FrootFollowersWillNowLeave()
	{
        
        int TotalFrootFollowers = 0;

        foreach(var o in NPCSystem.followers)
        {
            if(o.Type == "Fo")
            {
                TotalFrootFollowers++;
            }
        }

        int[] FrootIDs = new int[TotalFrootFollowers];

        foreach (var o in NPCSystem.followers)
        {
            if(o.Type == "Fo")
            {
                for(int i=0; i<TotalFrootFollowers;i++)
                {
                    FrootIDs[i] = o.id;
                }
            }
        }

        int FrootIDIndexToLeave = Random.Range(0, FrootIDs.Length - 1);
        int FrootIDToLeave = FrootIDs[FrootIDIndexToLeave];

        //NPCSystem.removeFollower(FrootIDToLeave);

        yield return new WaitForSeconds(5f);

	}

    private IEnumerator FerroFollowersWillNowLeave()
    {

        int TotalFerroFollowers = 0;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "Fr")
            {
                TotalFerroFollowers++;
            }
        }

        int[] FerroIDs = new int[TotalFerroFollowers];

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "Fr")
            {
                for (int i = 0; i < TotalFerroFollowers; i++)
                {
                    FerroIDs[i] = o.id;
                }
            }
        }

        int FerroIDIndexToLeave = Random.Range(0, FerroIDs.Length - 1);
        int FerroIDToLeave = FerroIDs[FerroIDIndexToLeave];

        NPCSystem.removeFollower(FerroIDToLeave);

        yield return new WaitForSeconds(5f);

    }

    private IEnumerator MimaxFollowersWillNowLeave()
    {

        int TotalMimaxFollowers = 0;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "M")
            {
                TotalMimaxFollowers++;
            }
        }

        int[] MimaxIDs = new int[TotalMimaxFollowers];

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "M")
            {
                for (int i = 0; i < TotalMimaxFollowers; i++)
                {
                    MimaxIDs[i] = o.id;
                }
            }
        }

        int MimaxIDIndexToLeave = Random.Range(0, MimaxIDs.Length - 1);
        int MimaxIDToLeave = MimaxIDs[MimaxIDIndexToLeave];

        NPCSystem.removeFollower(MimaxIDToLeave);

        yield return new WaitForSeconds(5f);

    }

    private IEnumerator NomadFollowersWillNowLeave()
    {

        int TotalNomadFollowers = 0;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "N")
            {
                TotalNomadFollowers++;
            }
        }

        int[] NomadIDs = new int[TotalNomadFollowers];

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "M")
            {
                for (int i = 0; i < TotalNomadFollowers; i++)
                {
                    NomadIDs[i] = o.id;
                }
            }
        }

        int NomadIDIndexToLeave = Random.Range(0, NomadIDs.Length - 1);
        int NomadIDToLeave = NomadIDs[NomadIDIndexToLeave];

        NPCSystem.removeFollower(NomadIDToLeave);

        yield return new WaitForSeconds(5f);

    }

    // Update is called once per frame
    void Update()
    {
        CurrentFrootHappiness = FrootHappinessIndex.FrootHappiness;
        CurrentFerroHappiness = FerroHappinessIndex.FerroHappiness;
        CurrentMimaxHappiness = MimaxHappniessIndex.MimaxHappiness;
        CurrentNomadHappiness = NomadHappinessIndex.NomadHappiness;

        
		if(CurrentFrootHappiness < 4)
		{
		StartCoroutine (FrootFollowersWillNowLeave());
		}

        if(CurrentFerroHappiness < 4)
        {
            StartCoroutine(FerroFollowersWillNowLeave());
        }

        if(CurrentMimaxHappiness < 4)
        {
            StartCoroutine(MimaxFollowersWillNowLeave());
        }

        if(CurrentNomadHappiness < 4)
        {
            StartCoroutine(NomadFollowersWillNowLeave());
        }
    }
}
