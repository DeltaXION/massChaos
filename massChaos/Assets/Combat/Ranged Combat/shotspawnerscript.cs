using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotspawnerscript : MonoBehaviour
{
    public float bulletVelocity = 5f;
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    // Start is called before the first frame update
    void Start()
    {
        shootscript();

    }

    // Update is called once per frame
    void Update()
    {

        

    }
    void shootscript()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
        GameObject bullet = (GameObject)Instantiate(
                               bullet1,
                               transform.position + (Vector3)(direction * 0.5f),
                               Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
    }
}
