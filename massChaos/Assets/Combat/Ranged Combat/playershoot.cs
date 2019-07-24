using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour
{
    public float bulletVelocity = 5f;
    public GameObject bullet;
    public GameObject bullet1;
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
            StartCoroutine(Attackarrow());
            
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
}
