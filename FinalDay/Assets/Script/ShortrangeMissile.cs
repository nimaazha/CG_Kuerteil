using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShortrangeMissile : MonoBehaviour
{
    /*
     * this class makes behaviour of a rocket being launched if the player is in his range of sight
     */

    //explosion effect on the player
    public GameObject deathEffect;

    //the game object to have the enemy clone object after it is dead
    Transform deadEnemyClonelist;

    //range of seeing the player
    float sightRange = 250.0f;

    //this is the player to be targeted by this enemy rocket
    Transform targetPlayer;

    float distanceToPlayer = Mathf.Infinity;

    float distanceTravelled;

    BoxCollider boxCollider;

    Vector3 latestPosition;

    void Start()
    {
        latestPosition = transform.position;
    }

    void Awake()
    {
        // Set up the references.
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        deadEnemyClonelist = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(targetPlayer.position, transform.position);
        if (distanceToPlayer > sightRange)
        {
            transform.LookAt(targetPlayer.transform);
        }
        if (distanceToPlayer <= sightRange)
        {
            ShotTheRocket();
        }
    }

    private void ShotTheRocket()
    {
        transform.position += transform.forward * 150 * Time.deltaTime;
        distanceTravelled = Vector3.Distance(transform.position, latestPosition);
        if (distanceTravelled > 200)
        {
            MakeExplosion();
        }
    }

    void OnParticleCollision(GameObject other)
    {
        MakeExplosion();
    }

    void MakeExplosion()
    {
        //this will instantiate the deathEffect of every enemy object as it dies
        //transform.position locates the enemy and Quaternion.identity to avoid rotation
        GameObject deadClone = Instantiate(deathEffect, transform.position, Quaternion.identity);

        //moving to the empty gameobject to be respawned
        deadClone.transform.parent = deadEnemyClonelist;

        //removing enemy object from the scene after the explosion
        Destroy(gameObject, .5f);
    }
}
