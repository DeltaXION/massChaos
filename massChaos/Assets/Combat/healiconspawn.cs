using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healiconspawn : MonoBehaviour
{
    public float TimeToLive = 1f;
    private Rigidbody2D rb;
    Vector2 directon = new Vector2(0, 1);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, TimeToLive);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
