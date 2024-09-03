using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class EnableBody : MonoBehaviour
{
    /*! \class This script uses the canvas component of the Canvas UI to control what get's displayed first
     */

    // These are the two UIs that get enabled
    public GameObject bodyCanvas;
    public GameObject bodyCanvas2;
    

    
    public void enableCanvas()
    {
        /*! \brief This method enables both canvases at the same time but puts the preceeding canvas behind the initial one.
         */

        bodyCanvas2 = GameObject.Find("BodyCanvas (2)");
        bodyCanvas2.GetComponent<Canvas>().enabled = true;

        bodyCanvas = GameObject.Find("BodyCanvas");
        bodyCanvas.GetComponent<Canvas>().enabled = true;

        bodyCanvas.GetComponent<Canvas>().sortingOrder = 2;
        bodyCanvas2.GetComponent<Canvas>().sortingOrder = 1;


    }

    
    public void nextPage()
    {
        /*! \brief This method switched the order of the canvases according to the button pressed - Ex: this one is the "nextPageBtn".
         */

        bodyCanvas.GetComponent<Canvas>().sortingOrder = 1;
        bodyCanvas2.GetComponent<Canvas>().sortingOrder = 2;
    }

    
    public void backPage()
    {
        /*! \brief This method switched the order of the canvases according to the button pressed - Ex: this one is the "backPageBtn".
         */

        bodyCanvas.GetComponent<Canvas>().sortingOrder = 2;
        bodyCanvas2.GetComponent<Canvas>().sortingOrder = 1;
    }
}
