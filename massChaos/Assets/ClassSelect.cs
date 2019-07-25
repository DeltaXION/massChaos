using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClassSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown classOptions;
    List<string> classes = new List<string>() { "Warrior", "Maige", "Ranger" };

    public void Dropdown_IndexChange(int index)
    {
       // Debug.log(classes[index]);
    }

    void Start()
    {
        populateList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void populateList() {
       
        classOptions.AddOptions(classes);
    }
}
