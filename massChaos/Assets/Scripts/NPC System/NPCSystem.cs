using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{


    public static List<BaseCharachteristics> followers = new List<BaseCharachteristics>();
    // Start is called before the first frame update


void Start()
    {
        followers.Add(new BaseCharachteristics(1, "Broom", 20, 30,"N"));
        followers.Add(new BaseCharachteristics(2, "Groom", 25, 36, "F"));
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
