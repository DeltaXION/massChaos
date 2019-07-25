using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSow : MonoBehaviour

{
    Timer2 timer;
    public GameObject apple;
    public GameObject parentList;
    public float plantGrowDuration;
    static float harvestIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        harvestIn += Time.deltaTime;
        
    }

    public void AddApple()
    {
        var a = Instantiate(apple);
        Debug.Log(harvestIn);
        a.transform.SetParent(parentList.transform);
        a.transform.localScale = new Vector3(1, 1, 0);
        Debug.Log(a.tag);
        
    }
}
