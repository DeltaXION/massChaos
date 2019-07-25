using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject starterRoom;
    public GameObject dungeonGenerationObject;
    public Camera dungeonCamera;
    public GameObject DungeonUI;
    public GameObject playerPrefab;
    public void LoadByIndex(int sceneIndex)
    {
        setDungeonCamera();
        DungeonUI.SetActive(false);
        dungeonCamera = GameObject.Find("DungeonCamera").GetComponent<Camera>();
        DungeonCameraMovement dungeonCameraMovement = GameObject.Find("DungeonCamera").GetComponent<DungeonCameraMovement>();
        
        Camera mainCamera = GameObject.Find("BB_Main Camera").GetComponent<Camera>();
        mainCamera.enabled = false;

        
        
        
        Instantiate(starterRoom, new Vector3(-500, -500, -5f), Quaternion.identity);
        Instantiate(dungeonGenerationObject, new Vector3(-500,-500,-5f), Quaternion.identity);
        if (GameObject.FindGameObjectWithTag("dungeonPlayer") == null)
        {
            GameObject dungeonPlayer = Instantiate(playerPrefab, new Vector3(-500, -500, -5f), Quaternion.identity);
            dungeonCameraMovement.setTarget(dungeonPlayer);
        } else
        {
            GameObject dungeonPlayer = GameObject.FindGameObjectWithTag("dungeonPlayer");
            dungeonPlayer.transform.position = new Vector3(-500, -500, -5);
            dungeonCameraMovement.setTarget(dungeonPlayer);
        }
        

        //SceneManager.LoadScene(sceneIndex);



    }

    void setDungeonCamera()
    {

        // Use this for initialization
        
        dungeonCamera.enabled = true;
        dungeonCamera.orthographicSize = 10;
        dungeonCamera.transform.position = new Vector3(-500f, -500f, -10f);
        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        float targetaspect = 4.0f / 3.0f;

            // determine the game window's current aspect ratio
            float windowaspect = (float)Screen.width / (float)Screen.height;

            // current viewport height should be scaled by this amount
            float scaleheight = windowaspect / targetaspect;

            // obtain camera component so we can modify its viewport
            

            // if scaled height is less than current height, add letterbox
            if (scaleheight < 1.0f)
            {
                Rect rect = dungeonCamera.rect;

                rect.width = 1.0f;
                rect.height = scaleheight;
                rect.x = 0;
                rect.y = (1.0f - scaleheight) / 2.0f;

            dungeonCamera.rect = rect;
            }
            else // add pillarbox
            {
                float scalewidth = 1.0f / scaleheight;

                Rect rect = dungeonCamera.rect;

                rect.width = scalewidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scalewidth) / 2.0f;
                rect.y = 0;

            dungeonCamera.rect = rect;
            }
        
    }
}
