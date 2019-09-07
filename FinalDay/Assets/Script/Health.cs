using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    /*
     * 
     * 
     */

    //explosion effect on the player
    public GameObject deathEffect;

    float timeToLoad = 1f;

    //the amount of fuel for the spaceship
    private int health = 1000;

    public int HealthPlayer { get => health; set => health = value; }

    public void CalcHealth()
    {

        health--;

        if (health <= 0)
        {
            //here sends message to the MovePlayer script that the player is dead
            MakeExplosion();

            //here to invoke the RestartScene methode by string refrence
            Invoke("RestartScene", timeToLoad);
        }

    }

    void PlayerIsOverHealthbox()
    {
        health += 5;

        if (health > 100)
        {
            health = 100;
        }
    }

    void MakeExplosion()
    {
        //here to invoke the PlayerIsDead methode by string refrence
        SendMessage("PlayerNotHealthy");

        //here starts to simulate the explosion by activating the ExplosionSimulator attached to player
        deathEffect.SetActive(true);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
