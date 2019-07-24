using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairscript : MonoBehaviour
{
   // private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
       //rb.angularVelocity = 0;
    }
}
