using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraPosition : MonoBehaviour
{

    Vector3 startDistance;
    Vector3 distance;

    public GameObject thisGameObject;



    // Use this for initialization
    void Start()
    {
        startDistance = thisGameObject.transform.position - transform.position;
        distance = startDistance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = thisGameObject.transform.position - distance;
        Quaternion rotation = Quaternion.LookRotation(startDistance);
        transform.rotation = rotation;
    }

}
