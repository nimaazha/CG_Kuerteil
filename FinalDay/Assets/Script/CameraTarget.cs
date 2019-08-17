using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    Vector3 baseOffset = new Vector3(0, 3, -30);
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
