using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxCameraPosition;
    public Vector2 minCameraPosition;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void setTarget(GameObject newPlayer)
    {
        target = GameObject.FindGameObjectWithTag("dungeonPlayer").transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        SmoothDungeonCameraPan();
    }

    void SmoothDungeonCameraPan()
    {
        if (target!=null && transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
           // targetPosition.x = Mathf.Clamp(targetPosition.x, minCameraPosition.x, maxCameraPosition.x); //clamp camera on x axis
           // targetPosition.y = Mathf.Clamp(targetPosition.y, minCameraPosition.y, maxCameraPosition.y); //clamp camera on y axis
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
