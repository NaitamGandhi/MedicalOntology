using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class setImageSize : MonoBehaviour
{
    /*! \class setImageSize
     * \brief This script is used to resize and relocate the background image (this black translucent  background) when the nodenemu is open.
     * 
     * It resizes it for the transition from "NodemenuStart" to "NodemenePanel" when the "View Details" button is clicked.
     */
    public void setImage(Image image)
    {
        /*! \brief This is the methods that takes in the image as an arguments ans uses it's objectRectTransform to resize and re locate the image's central point.
         */
        RectTransform objectRectTransform = image.GetComponent<RectTransform>();
        objectRectTransform.sizeDelta = new Vector2(540, 280);
        objectRectTransform.anchorMin = new Vector2(0.5f, 0.45f);
        objectRectTransform.anchorMax = new Vector2(0.5f, 0.45f);

        //objectRectTransform.transform.position = new Vector3(445, 220, 0);

    }
    
}
