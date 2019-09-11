using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    /*
     * with the help of this class the camera located on the player
     * follows the player from behind with the range set in the baseOffset
     * and looks to the player as it moves around
     */

    Vector3 baseOffset = new Vector3(0, 2f, - 20);
    Vector3 offset;
    public GameObject thisGameObject;

    // Update is called once per frame
    void Update()
    {
        Vector3 staticOffset = Quaternion.AngleAxis(thisGameObject.transform.eulerAngles.y, Vector3.up) * baseOffset;
        offset = staticOffset;

        transform.position = thisGameObject.transform.position + offset;
        
        transform.LookAt(thisGameObject.transform.position);
    }
}
