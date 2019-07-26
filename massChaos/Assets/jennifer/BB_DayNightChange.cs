using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_DayNightChange : MonoBehaviour
{
    Timer2 timer;
    [SerializeField] GameObject square;
    public Sprite TheSquare;
    public Color morningColor, noonColor, eveningColor, nightColor, harshColor;
    Color currentColor;
    SpriteRenderer myRenderer;


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.color = morningColor;
        currentColor = morningColor;
        timer = FindObjectOfType<Timer2>();


      /*  SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(spriteRenderer);

        spriteRenderer.sprite = TheSquare;
        spriteRenderer.color = new Color(1, 0, 0, .5f);

        GameObject square = new GameObject("square", typeof(SpriteRenderer));
        SpriteRenderer squareSpriteRenderer = square.GetComponent<SpriteRenderer>();
        squareSpriteRenderer.sprite = TheSquare;*/
    }

    // Update is called once per frame
    void Update()
    { // initial approach 
      /* if (timer.timeOfDay > 10)
       {
           square.SetActive(true);
           Debug.Log("SpriteRenderer Change Working");


       }*/

        // 2nd Trial 

        if(timer.timeOfDay > 0)
        {
            square.SetActive(true);
            Debug.Log("SpriteRenderer Change Working");
            currentColor = morningColor;
        }
        if (timer.timeOfDay > 75)
        {
            currentColor = noonColor;
        }



        if (timer.timeOfDay > 150)
        {
            currentColor = eveningColor;
        }

        if (timer.timeOfDay > 225)
        {
            currentColor = nightColor;
        }

        if (timer.harshWeathers == true)
        {
            currentColor = harshColor;
        }



        myRenderer.color = Color.Lerp(myRenderer.color, currentColor, 0.01f);
        

    }
}
