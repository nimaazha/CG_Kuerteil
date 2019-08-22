﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class MovePlayer : MonoBehaviour
{

    /*
     * unityDoc
     * https://docs.unity3d.com/Manual/DirectionDistanceFromOneObjectToAnother.html
     * 
     */

    //to calculate the amount of fuel
    FuelHandler fh;

    //check if player alive
    Boolean isAlive = true;

    //check if there is still fuel for the spaceship
    Boolean isFuelNotEmpty = true;

    //Rigidbody attached to spaceship
    Rigidbody m_Rigidbody;

    //Audio attached to spaceship
    public AudioSource[] audioSource;

    //a list of the player weapons (particle system)
    public ParticleSystem weaponRight;
    public ParticleSystem weaponLeft;
    public ParticleSystem weaponMiddle;

    //start speed of the Spaceship
    float m_Speed;

    //rotation speed
    float rotationSpeed;

    //maximum speed of the spaceship
    const float m_maxSpeed = 100.0f;

    //minimum speed of the spaceship
    const float m_minSpeed = 70.0f;

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

        latestPosition = transform.position;

        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();

        //
        fh = GetComponent<FuelHandler>();

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

        print("dt: " + distanceTravelled);

        //showing information on game panel
        SetShowAltitude(latestPosition);
        setShowSpeed(countSpeed);

        //print(fh.Fuel);
        setShowFuel(fh.Fuel);

    }

    // Here can things happen more than once in a frame
    void FixedUpdate()
    {

        //as long as player alive the controls are enabled
        if (isAlive && isFuelNotEmpty)
        {
            EngineControl();
            MovementControl();
            FireControl();
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

            distanceTravelled += Vector3.Distance(transform.position, latestPosition);
            distanceTravelled = UnityEngine.Mathf.Round(distanceTravelled);
            fh.CalcFuel(distanceTravelled);
        }

        // else if !(Input.GetKey(KeyCode.UpArrow)) AND m_speed > 0 then
        // m_speed = m_speed - 1 oder so ähnlich.  auf jeden fall pro frame immer langsamer werden
        // muss vielleicht auch in update statt fixed update

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

    //this method activates/disactivate the fire of laser guns attached to the player
    private void FireControl()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SetWeaponPower(true);               //activating fire
            StartCoroutine("PlaySound",0.2f);   //activating the sound of laser gun shot
        }
        else
        {
            SetWeaponPower(false);
            audioSource[1].Stop();
        }
    }

    //this method gives a pause between gun shots to help playing the sound of a shot correctly
    IEnumerator PlaySound(float delayTime)
    {
        //wait the time defined at the delay parameter  
        yield return new WaitForSeconds(delayTime);
        audioSource[1].Play();
        StopCoroutine("PlaySound");
    }

    //this method works togather with FireControl to control the fire of laser guns attached to the player
    private void SetWeaponPower(bool isActive)
    {
        var emission_weaponMiddle = weaponMiddle.emission;
        var emission_weaponLeft = weaponLeft.emission;
        var emission_weaponRight = weaponRight.emission;
        emission_weaponLeft.enabled = isActive;
        emission_weaponRight.enabled = isActive;
        emission_weaponMiddle.enabled = isActive;
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
        showAltitude.text = "Altitude: " + transform.position.y.ToString("0.00") + " Meter";
    }

    public void setShowSpeed(float countSpeed)
    {
        //starting to show the speed
        showSpeed.text = "Speed: " + countSpeed.ToString("0.00") + " KmH";
    }

    public void setShowFuel(int countFuel)
    {

        if (countFuel <= 30)
        {
            showFuel.color = new Color(1f, 0.5f, 0.8f);
        }

        //starting to show the fuel
        showFuel.text = "Fuel: " + countFuel.ToString() + " Liter";
    }
}