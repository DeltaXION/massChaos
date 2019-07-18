using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGold : MonoBehaviour
{
    public GameObject dungeonGold;                                                                                          
    

    // Start is called before the first frame update
    void Start()
    {
        dropGold(2,3,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dropGold(int enemyType, int enemyLevel,float enemyLocationX,float enemyLocationY)                               //drops gold based on enemy type and its level(basically dungeon runs). you need to pass
    {                                                                                                                           //enemy type, enemy level amd player location(x,y)
        float n = 0;
        for (int i = 0; i < enemyType; i++)
        {
            for (int j = 0; j < enemyLevel; j++)
            {
                Instantiate(dungeonGold, new Vector2(enemyLocationX + n, enemyLocationY + n), Quaternion.identity);
                n += 0.3f;
            }
        }
    }
}
