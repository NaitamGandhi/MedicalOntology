using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


 
public class destroyCanvas : MonoBehaviour
{
    /*! \class destroyCanvas 
     * \brief This script works on the the UI. More specifically this script controls the back and the close button in the nodemenu UI and "view details" UI respectively.
     */

    // These gameobjects are the ones being maniputaled
    public GameObject nodeMenu;
    public GameObject bodyCanvas;
    public GameObject bodyCanvas2;

    
    public void destoryNodeMenu()
    {
        /*! \brief This method destroies the entire nodemenu UI.
         */

        Destroy(nodeMenu);
        
    }

    public void close()
    {
        /*! \brief This method the canvas and the nodemenu beacuse they will be open when the user clicks through the UI.
         */

        Destroy(nodeMenu);
        Destroy(bodyCanvas);
        Destroy(bodyCanvas2);
    }
}
