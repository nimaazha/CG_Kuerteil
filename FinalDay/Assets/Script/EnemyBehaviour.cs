using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    /*
     * the first Idea of how to kill and delete the enemy from the scene was from unityDoc
     * https://docs.unity3d.com/Manual/CreateDestroyObjects.html
     * https://docs.unity3d.com/ScriptReference/Quaternion-identity.html
     * https://docs.unity3d.com/Manual/class-ParticleSystem.html 
     * 
     */

    //explosion effect on the player
    public GameObject deathEffect;

    //the game object to have the enemy clone object after it is dead
    public Transform deadEnemyClonelist;

    void Start()
    {
        if(gameObject.GetComponent<BoxCollider>() == null)
        {
            AddBoxColliderToGameobject();   
        }
    }

    private void AddBoxColliderToGameobject()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        boxCollider.size = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void OnParticleCollision(GameObject other)
    {
        MakeExplosion();
    }

    void MakeExplosion()
    {
        //to check if the colliding is working fine
        print("Enemy " + gameObject.name + " is Dead");

        //this will instantiate the deathEffect of every enemy object as it dies
        //transform.position locates the enemy and Quaternion.identity to avoid rotation
        GameObject deadClone = Instantiate(deathEffect, transform.position, Quaternion.identity);

        //moving to the empty gameobject to be respawned
        deadClone.transform.parent = deadEnemyClonelist;

        //removing enemy object from the scene after the explosion
        Destroy(gameObject, .5f);
    }
}
