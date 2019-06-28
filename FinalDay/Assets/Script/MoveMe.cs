using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour
{

    float speed = 10.0F;
    Vector3 objPosition;
    Transform target;
    float rotationAngel;

    void Start()
    {
        //hiding the mouse cursor during the game
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        //getting the actual position
        objPosition = transform.position;

        //making the Move
        Move(xPos, yPos);

        //if the escape key has been pressed - show the mouse icon
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }

    /*
     * checks the actual position 
     * if on the border, controls the object not leaving the gameboard
     */
    void Move(float xPos, float yPos)
    {
        //
        rotationAngel += xPos / 100;

        Vector3 targetDirection = new Vector3(Mathf.Sin(rotationAngel), 0, Mathf.Cos(rotationAngel));

        transform.position = objPosition;

        //define new position
        float moveHorizontal = xPos * speed * Time.deltaTime;
        float moveVertical = yPos * speed * Time.deltaTime;

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(targetDirection);

        transform.Translate(movement, Space.Self);
    }

    void checkRegion()
    {
        if (objPosition.x >= 25)
        {
            objPosition.x -= 5;
        }
        else if (objPosition.x <= -25)
        {
            objPosition.x += 5;
        }
        else if (objPosition.z >= 25)
        {
            objPosition.z -= 5;
        }
        else if (objPosition.z <= -25)
        {
            objPosition.z += 5;
        }
    }
}
