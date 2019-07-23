using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_DayNightChange : MonoBehaviour
{
    Timer2 timer;
    [SerializeField] GameObject square;

    // Start is called before the first frame update
    void Start()
    {
        
        timer = FindObjectOfType<Timer2>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeOfDay > 10)
        {
            square.SetActive(true);
            Debug.Log("SpriteRenderer Change Working");
        }
    }
}
