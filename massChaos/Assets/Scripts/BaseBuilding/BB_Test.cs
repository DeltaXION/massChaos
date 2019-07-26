using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Test : MonoBehaviour
{
    List<BaseCharachteristics> FollowerList = NPCSystem.followers;

    string[] applicantName = new string[5];

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            foreach (var m in FollowerList)
            {
                Debug.Log(m.Name + "AAAAAAAAAAAAAAAAAAAAAA");
                int i = 0;
                applicantName[i] = m.name;
                Debug.Log(applicantName[i]);

                i++;

                
            }
        }
       
    }
}
