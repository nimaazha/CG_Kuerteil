using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{


    Transform camPos;
    Vector3 baseOffset = new Vector3(0, 1, -2);
    Vector3 offset;
    public GameObject thisGameObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = camPos.position + objPos;
        //Quaternion rotation = Quaternion.LookRotation(objPos);

        Vector3 staticOffset = Quaternion.AngleAxis(thisGameObject.transform.eulerAngles.y, Vector3.up) * baseOffset;
        offset = staticOffset;

        transform.position = thisGameObject.transform.position + offset;

        transform.LookAt(thisGameObject.transform.position);
    }
}
