using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;



public class cutNode : MonoBehaviour
{
    /*! \class cutNode
     * \brief This script adds node-detaching functionality.
     * 
     * This script is used to add the functionality of the "Cut Node" button. The purpose of this button is to give the user the ability to un-link the link of the node from the rest of the Ontology or its lineage, for it to be then attached elsewhere.
     */
    GameObject hitObject; // This variale is to store the clicked node
    string node;

    void Start()
    {
        /*! \brief This finds the object's classID and assigns it to the hitobject to get its identity.
         */
        node = GameObject.Find("ClassID").GetComponent<Text>().text;
        hitObject = findNode(node);

    }

    
    public void NodeCut()
    {
        /*! \brief This method just disables the line renderering component of that identified node.
         */

        hitObject.GetComponent<LineRenderer>().enabled = false;
    }

    
    public GameObject findNode(string nodeName)
    {
        /*! \brief This method converts the string nodename of the the node into a gameobject.
         */

        GameObject obj = GameObject.Find(nodeName);
        if (obj != null)
            return obj;
        else
            return null;
    }
}
