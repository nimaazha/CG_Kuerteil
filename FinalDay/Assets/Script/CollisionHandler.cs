using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //as long as the only loader for the scene

public class CollisionHandler : MonoBehaviour
{

    /*
     * this class handles the collision of player to any surfaces or being hit by the enemy
     */

    //show alert for player on the scene
    public Text alertText;

    //show count time to go back to arena
    public Text showTime;

    bool isTrue;

    //to count time if player leaves the arena
    float counter = 15;

    //explosion effect on the player
    public GameObject deathEffect;

    //time to reload the scene
    float timeToLoad = 1f;

    void Update()
    {
        StartToCount();
    }

    void OnCollisionEnter(Collision collision)
    {
        //if player hits the ground or the buildings in playscene
        if(collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Building")
        {

            //here sends message to the MovePlayer script that the player is dead
            MakeExplosion();

            //here to invoke the RestartScene methode by string refrence
            Invoke("RestartScene", timeToLoad);

        }

        //if a longrange rocket hits the player
        if(collision.gameObject.tag == "LongrangeMissile")
        {
            BeingHit();
        }
    }

    //in case of being hit by particles of a rocket if they are exploded near to the player
    void OnParticleCollision(GameObject other)
    {
        SendMessage("CalcHealth");
    }

    //making the function to refule or 
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Fuel")
        {
            Refuel();
        }

        if(collider.gameObject.tag == "Health") 
        {
            Recover();
        }

        if (collider.gameObject.tag == "Arena")
        {
            isTrue = true;
            alertText.text = "You are leaving the arena soldier... You have 15 sec or you will die!";
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //if player is back at the arena
        if (collider.gameObject.tag == "Arena")
        {
            isTrue = false;
            counter = 15;
            alertText.text = "";
            showTime.text = "";
        }
        
    }
    void Refuel()
    {
        SendMessage("PlayerIsOverFueltank");
    }

    void Recover()
    {
        SendMessage("PlayerIsOverHealthbox");
    }

    void BeingHit()
    {
        SendMessage("CalcHealth");
    }

    void StartToCount()
    {
        if (isTrue)
        {
            counter -= Time.deltaTime;
            showTime.text = counter.ToString("0");
            print(counter);

            if (counter < 0)
            {
                MakeExplosion();

                //here to invoke the RestartScene methode by string refrence
                Invoke("RestartScene", timeToLoad);
            }
        }
    }

    void MakeExplosion()
    {
        //here to invoke the PlayerIsDead methode by string refrence
        SendMessage("PlayerIsDead");

        //here starts to simulate the explosion by activating the ExplosionSimulator attached to player
        deathEffect.SetActive(true);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
