using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEntry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        transform.SetParent(GameObject.Find("NPCList").transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
