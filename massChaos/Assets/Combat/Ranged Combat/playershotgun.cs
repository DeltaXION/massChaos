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
    public PlayerState st;
    int weaptype;
    //public GameObject pself; 
    public float TimeToLive = 5f;
    float startTime;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        weaptype= gameObject.GetComponent<PlayerMovement>().pweapon;
        //state current;
        st = gameObject.GetComponent<PlayerMovement>().currentState;
        if (weaptype == 5)
        {
            if (Input.GetButtonDown("attack") /*&& currentState != PlayerState.attack*/)
            {
                //currentState =
                timer += Time.fixedDeltaTime;
                startTime = Time.time;
                //  Debug.Log(timer);
                // Debug.Log("press");
                //StartCoroutine(Attackshotgun());
                st = PlayerState.walkslow;

            }
            if (Input.GetButtonUp("attack"))

            {
                // Debug.Log("release");
                // if (timer >= 0.1f)
                if (Time.time - startTime >= 0.1f)
                {
                    StartCoroutine(Attackshotgun2());
                }
                else
                    StartCoroutine(Attackshotgun());
                st = PlayerState.walk;

            }
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
    private IEnumerator Attackshotgun2()
    {
        // animator.SetBool("attacking", true);
        // currentState = PlayerState.attack;
        yield return null;
        //Debug.Log(myRigidbody.velocity);
        // animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.2f);
        //pself.PlayerMovement.currentState = PlayerState.walk;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        Vector2 direction2 = direction * new Vector2(1, 1);
        Vector2 direction3 = direction * new Vector2(1, 1);
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
                                transform.position + (Vector3)(direction2 * 0.3f),
                                Quaternion.identity);
        GameObject bullet3 = (GameObject)Instantiate(
                                bullet,
                                transform.position + (Vector3)(direction3 * 0.7f),
                                Quaternion.identity);

        //rotate bullets
        bullet2.transform.Rotate(0, 0, 90);


        // Adds velocity to the bullet
        bullet1.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        bullet2.GetComponent<Rigidbody2D>().velocity = direction2 * bulletVelocity;
        bullet3.GetComponent<Rigidbody2D>().velocity = direction3 * bulletVelocity;
    }
}
