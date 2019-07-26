using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSeedBank : MonoBehaviour
{
    public GameObject seedsPanel1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        seedsPanel1.transform.localScale = new Vector3(0, 0, 0);
    }
}
