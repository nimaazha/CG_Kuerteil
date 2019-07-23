using System;
using UnityEngine;
using UnityEngine.UI;



public class MovePlayer : MonoBehaviour
{
    //to calculate the amount of fuel
    FuelHandler fh = new FuelHandler();

    //check if player alive
    Boolean isAlive = true;

    //check if there is still fuel for the spaceship
    Boolean isFuelNotEmpty = true;

    //Rigidbody attached to spaceship
    Rigidbody m_Rigidbody;

    //Audio attached to spaceship
    AudioSource audioSource;

    //start speed of the Spaceship
    float m_Speed;

    //rotation speed
    float rotationSpeed;

    //maximum speed of the spaceship
    const float m_maxSpeed = 100.0f;

    //minimum speed of the spaceship
    const float m_minSpeed = 50.0f;

    //latest position of spaceship
    Vector3 latestPosition;

    //calculating how much the spaceship has been moved
    float distanceTravelled;

    //showing altitude on the gamepanel
    public Text showAltitude;

    //showing speed on the gamepanel
    public Text showSpeed;

    //showing fuel on the gamepanel
    public Text showFuel;

    float countSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();

        //Get component for audioSource
        audioSource = GetComponent<AudioSource>();

        //Set the speed of the GameObject
        m_Speed = 10.0f;

        //set the roatation speed
        rotationSpeed = 30.0f;

        //counting Altitude
        SetShowAltitude(latestPosition);

        //init var counting Speed
        countSpeed = 0.0f;
        setShowSpeed(countSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        latestPosition = transform.position;
        distanceTravelled = Vector3.Distance(transform.position, latestPosition);

        //showing information on game panel
        SetShowAltitude(latestPosition);
        setShowSpeed(countSpeed);

        print("dt: " + distanceTravelled);
        //print(fh.Fuel);
        setShowFuel(fh.Fuel);
        

        fh.CalcFuel(distanceTravelled);
    }

    // Here can things happen more than once in a frame
    void FixedUpdate()
    {
        //as long as player alive the controls are enabled
        if (isAlive && isFuelNotEmpty)
        {
            EngineControl();
            MovementControl();

        }

    }

    //this method simulates the work of an engine -- giving speed
    void EngineControl()
    {
        //calc the deltaTimeFrame
        float calcDeltaTime = Time.deltaTime * m_Speed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Rigidbody.MovePosition(transform.position + transform.forward * calcDeltaTime);
            m_Speed -= transform.forward.y * Time.deltaTime * 40.0f;
            if (m_Speed < m_minSpeed)
            {
                m_Speed = m_minSpeed;
            }
            else if (m_Speed > m_maxSpeed)
            {
                m_Speed = m_maxSpeed;
            }

            countSpeed = m_Speed;

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
    }


    void MovementControl()
    {
        //to avoid any unwanted rotation
        m_Rigidbody.freezeRotation = true;

        //calculate the deltaTimeFrame
        float calcDeltaTime = Time.deltaTime * rotationSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            //Rotate the sprite about the Z axis in the counter clockweis direction
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(1, 0, 0) * calcDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Rotate the sprite about the Z axis in the clockweis direction
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(-1, 0, 0) * calcDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Rotate the sprite about the Z axis in the counter clockweis direction
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, 1) * calcDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Rotate the sprite about the Z axis in the clockweis direction
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, -1) * calcDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Z axis in the counter clockweis direction
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, -1, 0) * calcDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Z axis in the clockweis direction
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1, 0) * calcDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }

    }

    //check for the height of to simulate collision to the terrain
    void CheckHeightDifferential()
    {
        //height of Terrain on the location where our player flights 
        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);

        //correcting the position of player in Y-Axis to not to go through Terrain
        if (terrainHeight > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight + 1.4f, transform.position.z);
            //Destroy(this);
        }
    }

    //this method is called in Class CollisionHandler by string refrence on collision of player to any object in the scene
    void PlayerIsDead()
    {
        isAlive = false;
    }

    //this method is called in Class FuelHandler by string refrence on having no more fuel and causes dead of the player
    void FuelIsEmpty()
    {
        isFuelNotEmpty = false;
    }

    public void SetShowAltitude(Vector3 latestPosition)
    {
        //starting to show the altitude
        showAltitude.text = "Altitude: " + latestPosition.y.ToString() + " Meter";
    }

    public void setShowSpeed(float countSpeed)
    {
        //starting to show the speed
        showSpeed.text = "Speed: " + countSpeed.ToString() + " KmH";
    }

    public void setShowFuel(int countFuel)
    {
        //starting to show the fuel
        showFuel.text = "Fuel: " + countFuel.ToString() + " Liter";
    }
}
