using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timetolive : MonoBehaviour
{
    public float TimeToLive = 5f;
    private void Start()
    {
        Destroy(this.gameObject, TimeToLive);
    }
}
