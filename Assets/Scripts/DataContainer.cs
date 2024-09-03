using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataContainer : MonoBehaviour
{
    /*! \class DataContainer
     * \brief All of the data taken from the "CVDO" excel fine is stored into the varialbe listed in this file, hence the "data container".
     */

    public string id;
    public string label;
    public string parent;
    public List<string> children;
    public List<GameObject> siblings;
    public int numDescendants;
    public int linknum;
    public string description;
    public int layernum;
    public int layerOrder;
    public string synonyms;
}
