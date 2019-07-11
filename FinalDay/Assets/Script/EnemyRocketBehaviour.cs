﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRocketBehaviour : MonoBehaviour
{
    /*
     * this class makes behaviour of a rocket being launched if the player is in his range of sight
     */

    //explosion effect on the player
    public GameObject deathEffect;

    //the game object to have the enemy clone object after it is dead
    public Transform deadEnemyClonelist;

    //range of seeing the player
    float sightRange = 200.0f;

    //this is the player to be targeted by this enemy rocket
    public Transform targetPlayer;

    float distanceToPlayer = Mathf.Infinity;

    float distanceTravelled;

    Collider boxCollider;

    public Vector3 latestPosition;

    void Start()
    {
        if (gameObject.GetComponent<BoxCollider>() == null)
        {
            AddBoxColliderToGameobject();
        }
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(targetPlayer.position, transform.position);
        if(distanceToPlayer <= sightRange)
        {
            ShotTheRocket();
        }
    }

    private void ShotTheRocket()
    {
        latestPosition = transform.position;
        transform.LookAt(targetPlayer.transform);
        transform.position += transform.forward * 70 * Time.deltaTime;
        distanceTravelled = Vector3.Distance(transform.position, latestPosition);
        if(distanceTravelled > 50)
        {
            MakeExplosion();
        } 
    }

    private void AddBoxColliderToGameobject()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
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
