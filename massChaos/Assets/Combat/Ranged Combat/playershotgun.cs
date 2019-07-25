using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershotgun : MonoBehaviour
{
    public float bulletVelocity = 5f;
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    public float TimeToLive = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("attack") /*&& currentState != PlayerState.attack*/)
        {
            //currentState =
            StartCoroutine(Attackshotgun());

        }
    }
    private IEnumerator Attackshotgun()
    {
        // animator.SetBool("attacking", true);
        // currentState = PlayerState.attack;
        yield return null;
        //Debug.Log(myRigidbody.velocity);
        // animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.2f);
        // currentState = PlayerState.walk;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        Vector2 direction2 = direction * new Vector2(2,1);
        Vector2 direction3 = direction * new Vector2(1, 2);
        direction.Normalize();
        direction2.Normalize();
        direction3.Normalize();
        // Creates the bullet locally
        GameObject bullet1 = (GameObject)Instantiate(
                                bullet,
                                transform.position + (Vector3)(direction * 0.5f),
                                transform.rotation);
        GameObject bullet2 = (GameObject)Instantiate(
                                bullet,
                                transform.position + (Vector3)(direction2 * 0.5f),
                                Quaternion.identity);
        GameObject bullet3 = (GameObject)Instantiate(
                                bullet,
                                transform.position + (Vector3)(direction3 * 0.5f),
                                Quaternion.identity);

        //rotate bullets
        bullet2.transform.Rotate(0, 0, 90);


        // Adds velocity to the bullet
        bullet1.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        bullet2.GetComponent<Rigidbody2D>().velocity = direction2 * bulletVelocity ;
        bullet3.GetComponent<Rigidbody2D>().velocity = direction3 * bulletVelocity;
    }
}
