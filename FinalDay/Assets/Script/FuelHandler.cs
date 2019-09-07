using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuelHandler : MonoBehaviour
{
    /*
     * unityDoc
     * 
     */

    //explosion effect on the player
    public GameObject deathEffect;

    float timeToLoad = 1f;

    //the amount of fuel for the spaceship
    private int fuel = 100;

    public int Fuel { get => fuel; set => fuel = value; }

    public void CalcFuel(float distanceTravelled)
    {
        int isRestZero = 1;

        if (distanceTravelled >= 5000)
        {
            isRestZero = (int)distanceTravelled % 50000;
            if (isRestZero <= 150)
            {
                isRestZero = 0;
            }
        }

        if (fuel > 0 && isRestZero == 0)
        {
            fuel -= 10;
        }

        if (fuel == 0)
        {
            //here sends message to the MovePlayer script that the player is dead
            MakeExplosion();

            //here to invoke the RestartScene methode by string refrence
            Invoke("RestartScene", timeToLoad);
        }

    }

    void PlayerIsOverFueltank()
    {
        fuel += 20;
        if (fuel > 100)
        {
            fuel = 100;
        }
    }

    void MakeExplosion()
    {
        //here to invoke the PlayerIsDead methode by string refrence
        SendMessage("FuelIsEmpty");

        //here starts to simulate the explosion by activating the ExplosionSimulator attached to player
        deathEffect.SetActive(true);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
