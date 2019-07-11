using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //as long as the only loader for the scene

public class CollisionHandler : MonoBehaviour
{

    /*
     * this class handles the collision of player to any surfaces or being hit by the enemy
     * by calling the SendMessage("MethodeName") the method with the same name will be called in any
     * script under player
     * 
     * https://docs.unity3d.com/ScriptReference/GameObject.SendMessage.html
     * https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html
     * 
     */

    //explosion effect on the player
    public GameObject deathEffect;

    float timeToLoad = 1f;

    void OnCollisionEnter(Collision collision)
    {
        //here sends message to the MovePlayer script that the player is dead
        MakeExplosion();

        //here to invoke the RestartScene methode by string refrence
        Invoke("RestartScene", timeToLoad);
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
