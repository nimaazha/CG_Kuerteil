using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveSpaceship : MonoBehaviour
{
    //latest position of spaceship
    Vector3 latestPosition;

    //calculating how much the spaceship has been moved
    float distanceTravelled;

    //spaceship to be attached
    Rigidbody m_Rigidbody;

    //start speed of the Spaceship
    float m_Speed;

    //anti gravity speed to be able to fly
    float aGravitySpeed;

    //rotation speed
    float rotationSpeed;

    //maximum speed of the spaceship
    const float m_maxSpeed = 15.0f;

    //showing altitude on the gamepanel
    public Text showAltitude;

    //showing speed
    public Text showSpeed;
    float countSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();

        //Set the speed of the GameObject
        m_Speed = 20.0f;

        //set the speed of the anti gravity speed
        aGravitySpeed = 10.0f;

        //set the roatation speed
        rotationSpeed = 10.0f;

        latestPosition = transform.position;

        //init var counting Altitude
        setShowAltitude(latestPosition);

        //init var counting Speed
        countSpeed = 0.0f;
        setShowSpeed(countSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        latestPosition = transform.position;
        distanceTravelled = Vector3.Distance(transform.position, latestPosition);
    }

    // Here can things happen more than once in a frame
    void FixedUpdate()
    {
        engineControl();
        movementControl();

        //showing information on game panel
        setShowAltitude(latestPosition);
        setShowSpeed(countSpeed);
    }

    void engineControl()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {

            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.AddRelativeForce(transform.forward * m_Speed);

            if (m_Speed < m_maxSpeed)
            {
                m_Speed *= 1.001f;
                countSpeed = m_Speed;
            }
            if (m_Rigidbody.transform.eulerAngles.x < 0 || m_Rigidbody.transform.eulerAngles.x > -80)
            {
                m_Rigidbody.AddForce(transform.up * aGravitySpeed);
            }
            if ((m_Rigidbody.transform.eulerAngles.x > 0 || m_Rigidbody.transform.eulerAngles.x < 80))
            {
                m_Rigidbody.AddForce(-transform.up * aGravitySpeed);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (m_Speed > 0)
            {
                m_Speed /= 1.001f;
                countSpeed = m_Speed;
            }
            
            m_Rigidbody.AddRelativeForce(transform.forward * m_Speed);
        }
    }

    void movementControl()
    {
        //to avoid any unwanted rotation
        m_Rigidbody.freezeRotation = true;

        //calc the deltaTimeFrame
        float calcDeltaTime = Time.deltaTime * rotationSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            //Rotate the sprite about the Z axis in the counter clockweis direction
            transform.Rotate(new Vector3(1, 0, 0) * calcDeltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Rotate the sprite about the Z axis in the clockweis direction
            transform.Rotate(new Vector3(-1, 0, 0) * calcDeltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Rotate the sprite about the Z axis in the counter clockweis direction
            transform.Rotate(new Vector3(0, 0, 1) * calcDeltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Rotate the sprite about the Z axis in the clockweis direction
            transform.Rotate(new Vector3(0, 0, -1) * calcDeltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Z axis in the counter clockweis direction
            transform.Rotate(new Vector3(0, -1, 0) * calcDeltaTime, Space.Self);
         
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Z axis in the clockweis direction
            transform.Rotate(new Vector3(0, 1, 0) * calcDeltaTime, Space.Self); 
        }

    }

    void setShowAltitude(Vector3 latestPosition)
    {
        //starting to show the altitude
        showAltitude.text = "Altitude: " + latestPosition.y.ToString() + " Meter";
    }

    private void setShowSpeed(float countSpeed)
    {
        //starting to show the speed
        showSpeed.text = "Speed: " + countSpeed.ToString() + " KmH";
    }
}
