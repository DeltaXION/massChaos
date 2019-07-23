using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ApplicantAccept : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update
    NPCList n;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Yesss");

    }

    public void OnSelect(BaseEventData eventData)
    {
        string id = transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text.ToString();
        BaseCharachteristics b;
        if (this.gameObject.name == "accept") {
             b = NPCApplicants.GetFollowerByID(int.Parse((id)));
            NPCSystem.addFollower(b.Name, b.Type,"", "", "", "idle");
            
            Destroy(transform.parent.gameObject);
            NPCApplicants.removeFollower(int.Parse((id)));
        }
        if (this.gameObject.name == "reject")
        {
            transform.parent.gameObject.SetActive(false);
            NPCApplicants.removeFollower(int.Parse((id)));
        }
    }
}
