/*using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;



public class GetInfo : MonoBehaviour
{
    /*! \class GetInfo 
     * \brief This script is used to grab the information that's neccessary from the "DataContainer" script.
     * 
     * The script is attached to the "DataPoint" gameobject. It will then deteced if the user has clicked onto the node. If so, then it'll populate the "Body" of the "NodemenuPanel" of the Nodemenu prefab.
     * This script is in-progress to fix it's behaviour. The core problem is that when the nodemenu is active and if there's a node behind the menu, the click gets detected through the button on the menu, if there's another node in-line with that button.
     * For example, if you've already clicked on a node and the nodemenu has opened, when you try to click on "View Details" button right where you know there's is a node in-line/directcly behind the button, the nodemenu of that node will get activated.
     * Also the user should be able to click-hold and drag the node if they want to and be able to just click on the node to open the nodemenu. This functionality is still IN-PROGRESS (not a complete solution).
     * One fix that was being attempted was to count the seconds the user holds the node for, and if it's greater then two, then make it ignore the activation of the nodemenu and vice-versa for the other scenerio.
     */

    // This is for button press variables only to detect the seconds the user holds the 
    float timeCurrent;
    float timeAtButtonDown;
    float timeAtButtonUp;
    float timeButtonHeld = 0;
    bool draggable = false;

    // These are the variables used to store the infromation from the "DataContainer" values
    Text txt;
    string classID;
    string description;
    string parents;
    string classTitle; //this is the temperory string to take in the value of edited classID

    // These are to convert the strings variables into gameobject to later display as text
    GameObject classti, classid, descrip, paren; //classti is class title which needs to be displayed on top of the canvas, but it will extract the substring from classID
    GameObject hitObject;
    public GameObject nodeMenu;

    
    public void actionAfterHitOnNode()
    {
        /*! \brief This method detects a raycast hit on the node, runs the extraction of infromation from the datacontainers, stores it into the varibles, and attaches it to the "Body" to display as text.
         */
        MedicalPlotter plot = new MedicalPlotter();

        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hitInfo.transform != null)
        {
            hitObject = plot.findNode(hitInfo.transform.gameObject.name);

            if (hit && hitObject != null && hitObject.name != "Floor")
            {
                Debug.Log("Hit " + hitObject.name);
                hitObject.GetComponent<GrabNodes>().objectClicked = true;
                Instantiate(nodeMenu, new Vector3(0, 0, 0), transform.rotation);
                hitObject.transform.SetParent(null);

                classID = hitObject.transform.gameObject.GetComponent<DataContainer>().id; //gets the public class id
                description = hitObject.transform.gameObject.GetComponent<DataContainer>().description; //gets the public description
                parents = hitObject.transform.gameObject.GetComponent<DataContainer>().parent; //gets the public parents

                Debug.Log(classID);
                Debug.Log(description);
                Debug.Log(parents);


                if (classID.StartsWith("http:"))
                {
                    //remove "http..." part of the classID string
                    classTitle = classID.Substring(31).TrimStart();
                }

                classti = GameObject.Find("PreferedName");
                classid = GameObject.Find("ClassID");
                descrip = GameObject.Find("Description");
                paren = GameObject.Find("Parents");

                //this bottom one if for the title

                txt = classti.GetComponent<Text>();
                txt.text = classTitle;

                txt = classid.GetComponent<Text>();
                txt.text = classID;

                txt = descrip.GetComponent<Text>();
                txt.text = description;

                txt = paren.GetComponent<Text>();
                txt.text = parents;
            }
        }
    }
    
    void OnMouseDown()
    {
        /*! \fn method is where it starts the timer
         */
        timeAtButtonDown = timeCurrent;
        //Debug.Log("Time button pressed" + timeAtButtonDown);
    }

    
    void OnMouseUp()
    {
        /*! \fn This method is wher the timer stops and give a value to be evalutated
         */
        timeAtButtonUp = timeCurrent;
        //Debug.Log("Time button released" + timeAtButtonUp);

        timeButtonHeld = (timeAtButtonUp - timeAtButtonDown);
        //Debug.Log("TimeButtonHeld = " + timeButtonHeld);

    }
    
    void Update()
    {
        /*! \fn This update method is where the user's click is evaluated if it's greater or less then two seconds to either open the nodemenu or let the user manipulate the node itself to a different location/position.
        */

        timeCurrent = Time.fixedTime;
        OnMouseDown();
        OnMouseUp();

        if (Input.GetMouseButtonUp(0) && timeButtonHeld < 2)
        {
            actionAfterHitOnNode();
        }
    }
}