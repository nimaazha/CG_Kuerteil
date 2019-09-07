using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    /*
     * 
     * 
     */

    //to calculate the amount of fuel
    FuelHandler fh;

    //to calculate the amount of health
    Health health;

    ScoreTable score;

    //check if player alive
    Boolean isAlive = true;

    //check if there is still fuel for the spaceship
    Boolean isFuelNotEmpty = true;

    //check if there is any health for the player/spaceship
    Boolean isHealthy = true;

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

    //showing health on the gamepanel
    public Text showHealth;

    float countSpeed;

    // Start is called before the first frame update
    void Start()
    {

        latestPosition = transform.position;

        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();

        //getting the amount of fuel at start
        fh = GetComponent<FuelHandler>();

        //getting the amount of health
        health = GetComponent<Health>();

        //getting the amount of score
        score = GetComponent<ScoreTable>();

        //Set the speed of the GameObject
        m_Speed = 10.0f;

        //set the roatation speed
        rotationSpeed = 30.0f;

        //counting Altitude
        SetShowAltitude(latestPosition);

        //init var counting Speed
        countSpeed = 0.0f;
        setShowSpeed(countSpeed);

        // setShowScore(score.Scores);
    }

    // Update is called once per frame
    void Update()
    {
        //showing information on game panel
        SetShowAltitude(latestPosition);

        setShowSpeed(countSpeed);

        setShowFuel(fh.Fuel);

        setShowHealth(health.HealthPlayer);
    }

    // Here can things happen more than once in a frame
    void FixedUpdate()
    {

        //as long as the player is alive and the fuel not empty and the helath not zero the controls are enabled
        if (isAlive && isFuelNotEmpty && isHealthy)
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
            m_Rigidbody.velocity = Vector3.zero;
            m_Rigidbody.angularVelocity = Vector3.zero; 

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
        } //this will simulates a light and slow fall down if the UpArrow key is not pressed
        else if (!(Input.GetKey(KeyCode.UpArrow))) 
        {
             m_Rigidbody.AddForce(-transform.up * 10);
             m_Rigidbody.AddForce(transform.forward * 10);
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

    void PlayerNotHealthy()
    {
        isHealthy = false;
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
        } else
        {
            showFuel.color = new Color(255, 255, 255);
        }

        //starting to show the fuel
        showFuel.text = "Fuel: " + countFuel.ToString() + " Liter";
    }

    public void setShowHealth(int health)
    {
        showHealth.text = "Health: " + health.ToString();
    }

}