using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    public GameObject centralGameObject;    //This object is the cental object - example sun to earth
    public float orbitingSpeed;             //the speed that the objects has when orbiting
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        doOrbit();
    }

    private void doOrbit()
    {
        transform.RotateAround(centralGameObject.transform.position, direction, orbitingSpeed * Time.deltaTime);
    }
}
