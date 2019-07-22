using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    Vector3 startPosition;
    public GameObject house;
    private GameObject linehandler;
    private Vector3 mousepos;
    //float x;
    //float y;
    //float z;
    //public GameObject houseImg;

    public void OnBeginDrag (PointerEventData eventData)
    {
    //    //startPosition =  GameObject.Find("house_img").transform.position;
        startPosition = transform.parent.position;
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
    {
        //transform.position = Vector3.zero;
        //Destroy (clone, 0.1f);
        transform.localPosition = startPosition;
        //Debug.Log("Ennnnd" + transform.position.x);
        //Debug.Log("Ennnnnd" + transform.position.y);

        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        linehandler = Instantiate(house, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
        linehandler.transform.SetAsLastSibling();
        linehandler.transform.position = mousepos;


    }
}
