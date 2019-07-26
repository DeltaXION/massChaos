using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BB_FarmAssignment : MonoBehaviour
{
    List<BaseCharachteristics> permanentList = NPCSystem.followers;

    string[] assignmentName = new string[20];

    [SerializeField] Text npcAssignment;

    [Header("Button to ADD NPC")]
    [SerializeField] Button button1, button2;

    [Header("UI")]
    [SerializeField] GameObject statsUI, assignList;

    // Start is called before the first frame update
    void Start()
    {
        assignList.SetActive(true);
        npcAssignment.text = "Name: \n" + permanentList[0].name.ToString() + "\n\n" + permanentList[1].name.ToString();
    }

    private void Update()
    {
        statVisibilityCheck();
    }


    public void addNPCtoFarmFirstButton()
    {
        int i = 0;
        npcAssignment.text = permanentList[i].name.ToString() + " Works in Farm Now";
        assignmentName[0] = permanentList[i].name.ToString();

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        
        permanentList[i].status = "Farm";

        //NPCSystem.addFollower(ApplicantList[i].name,
        //                        ApplicantList[i].type,
        //                        ApplicantList[i].classType,
        //                        ApplicantList[i].secItem,
        //                        ApplicantList[i].priItem,
        //                        ApplicantList[i].status);

    }


    public void addNPCtoFarmSecondButton()
    {
        int i = 1;
        npcAssignment.text = permanentList[i].name.ToString() + " Works in Farm Now";
        assignmentName[0] = permanentList[i].name.ToString();

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        

        permanentList[i].status = "Farm";

        //NPCSystem.addFollower(ApplicantList[i].name,
        //                      ApplicantList[i].type,
        //                      ApplicantList[i].classType,
        //                      ApplicantList[i].secItem,
        //                      ApplicantList[i].priItem,
        //                      ApplicantList[i].status);

    }


    private void statVisibilityCheck()
    {
        if (Input.GetMouseButtonDown(0) && assignList.activeSelf)
        {
            // To Check if object hit any collider
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == null)
            {

                assignList.SetActive(false);
               
            }
        }
    }
}
