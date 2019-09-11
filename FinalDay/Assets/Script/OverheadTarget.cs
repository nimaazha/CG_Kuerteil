using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadTarget : MonoBehaviour
{

    /*
     * an easy implementation for the overhead camera to follow the player from the above
     * 
     * unityDoc
     * https://docs.unity3d.com/Manual/MultipleCameras.html
     * 
     */

    Vector3 baseOffset = new Vector3(0, 50, 0);

    public GameObject thisGameObject;

    // Update is called once per frame
    void Update()
    {
        
        transform.position = thisGameObject.transform.position + baseOffset;

        transform.LookAt(thisGameObject.transform.position);
    }
}
