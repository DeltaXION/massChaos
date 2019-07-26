using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HouseDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    public bool displayNPCassignList;

    NPCApplicants npc;

    Vector3 startPosition;
    public GameObject building;
    private GameObject linehandler;
    private Vector3 mousepos;
    //float x;
    //float y;
    //float z;
    //public GameObject houseImg;
    public int woodCountAvl;

    //bool isCollided;
    //int i = 0;

    Timer2 timer;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //    //startPosition =  GameObject.Find("house_img").transform.position;
        startPosition = transform.parent.position;
        //isCollided = false;

            //    x = GameObject.Find("house_img").transform.position.x;
            //    y =  GameObject.Find("house_img").transform.position.y;
            //    Debug.Log("Staaart" + x);
            //    Debug.Log("Staaart" + y);
            //    //clone = (GameObject)Instantiate(houseImg, startPosition, Quaternion.identity);


    }
    public void OnDrag(PointerEventData eventData)
    {


            //clone.GameObject.transform.position = Input.mousePosition;
            transform.position = Input.mousePosition;
      


        

    }




    public void OnEndDrag(PointerEventData eventData)
    {   transform.localPosition = startPosition;
        timer = FindObjectOfType<Timer2>();
        if (timer.timeOfDay < 150 && !Timer2.harshWeather)
        {


            if (ResourceManager.wood >= 5 && BB_BasicControls.houseBuilt < 4)
            {

  
                //transform.position = Vector3.zero;
                //Destroy (clone, 0.1f);


                //Debug.Log("Ennnnd" + transform.position.x);
                //Debug.Log("Ennnnnd" + transform.position.y);

                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                linehandler = Instantiate(building, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
                linehandler.transform.SetAsLastSibling();
                linehandler.transform.position = mousepos;
                linehandler.SetActive(true);
               
                //Collider[] hitColliders = Physics.OverlapBox(linehandler.transform.position, linehandler.transform.localScale / 2, Quaternion.identity);

                //Check when there is a new collider coming into contact with the box

                ResourceManager.subWood(5);
                BB_BasicControls.houseBuilt++;
                BB_BasicControls.buildBuilt++;
                CommonHappinessIndex.RecaclculateHappinessIndex();



                //npc = new NPCApplicants();
                //  npc.PopulateList();

                //Debug.Log(houseBuilt);
                displayNPCassignList = true;
            }




        }

    }
}
