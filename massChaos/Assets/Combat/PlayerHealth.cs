using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public Slider healthBarSlider;
    public int currenthealth;
    public int maxhealth;
    public Text healthtext;
    bool isdead;
    public GameObject icon;
    Vector2 playerpos;
    int maxpotions=5;
    int currentpotions;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        currentpotions = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("dungeonPlayer") != null)
        {
            playerpos = GameObject.FindGameObjectWithTag("dungeonPlayer").transform.position;
            healthBarSlider.maxValue = maxhealth;
            healthBarSlider.value = currenthealth;
            if (currenthealth >= maxhealth)
            {
                currenthealth = maxhealth;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currenthealth -= 10;
            }
            if (Input.GetButtonDown("Heal") && currentpotions > 0)
            {
                currentpotions -= 1;
                Debug.Log(currentpotions);
                currenthealth += 30;
                // Instantiate(icon);

            }
            if (currenthealth <= 0)
            {
                currenthealth = 0;
                GameObject.Find("Player").SetActive(false);
                healthtext.text = "you died!!!!!!!!!!!!!!11";

            }
        }
    }
}
