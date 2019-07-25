using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour
{
    public float bulletVelocity = 5f;
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject bulletsp;
    public GameObject bulletsp2;
    public float TimeToLive = 5f;
    public PlayerState st;
    float startTime;
    float timer = 0.0f;
    int weaptype;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //state current;
        weaptype = gameObject.GetComponent<PlayerMovement>().pweapon;
        st = gameObject.GetComponent<PlayerMovement>().currentState;
        if (weaptype == 4)
        {
            if (Input.GetButtonDown("attack") /*&& currentState != PlayerState.attack*/)
            {
                //currentState =
                timer += Time.fixedDeltaTime;
                startTime = Time.time;
                st = PlayerState.walkslow;
                // StartCoroutine(Attackarrow());

            }
            if (Input.GetButtonUp("attack"))

            {
                // Debug.Log("release");
                // if (timer >= 0.1f)
                if (Time.time - startTime >= 0.1f)
                {
                    StartCoroutine(Attackarrow2());
                }
                else
                    StartCoroutine(Attackarrow());
                st = PlayerState.walk;

            }
        }
    }

    private IEnumerator Attackarrow()
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
        direction.Normalize();
        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                bullet1,
                                transform.position + (Vector3)(direction * 0.5f),
                                Quaternion.identity);
        
        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
    }
    private IEnumerator Attackarrow2()
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
        direction.Normalize();
        // Creates the bullet locally
        GameObject bulletsp = (GameObject)Instantiate(
                                bulletsp2,
                                transform.position + (Vector3)(direction * 0.5f),
                                Quaternion.identity);

        // Adds velocity to the bullet
        bulletsp.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
    }
}
