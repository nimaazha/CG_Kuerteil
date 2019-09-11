using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LongrangeMissile : MonoBehaviour
{
    /*
     * this class makes behaviour of a rocket being launched if the player is in his range of sight
     * it works in a bigger range as shortmissile and it can follow the player in the scene
     * it will explodes after a defined range of fly
     */

    //range of seeing the player
    float sightRange = 1000.0f;

    //this is the player to be targeted by this enemy rocket
    Transform targetPlayer;

    //the game object to have the enemy clone object after it is dead
    Transform deadEnemyClonelist;

    float distanceToPlayer = Mathf.Infinity;

    float distanceTravelled;

    Vector3 latestPosition;

    //explosion effect on the player
    public GameObject deathEffect;
   
    void Start()
    {
        latestPosition = transform.position;
    }

    void Awake()
    {
        // Set up the references.
        targetPlayer = GameObject.FindGameObjectWithTag ("Player").transform;
        deadEnemyClonelist = GameObject.FindGameObjectWithTag("Respawn").transform;
    }


    void Update()
    {
        distanceToPlayer = Vector3.Distance(targetPlayer.position, transform.position);
        if (distanceToPlayer <= sightRange)
        {
            ShotTheRocket();
        }
    }

    private void ShotTheRocket()
    {
        transform.LookAt(targetPlayer.transform);
        transform.position += transform.forward * 70 * Time.deltaTime;
        distanceTravelled = Vector3.Distance(transform.position, latestPosition);
        if (distanceTravelled > 500)
        {
            MakeExplosion();
            ScoreTable.scores += 1;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        MakeExplosion();
        ScoreTable.scores += 5;
    }

    void OnCollisionEnter(Collision collision)
    {
        MakeExplosion();
    }

    void MakeExplosion()
    {
        //this will instantiate the deathEffect of every enemy object as it dies
        //transform.position locates the enemy and Quaternion.identity to avoid rotation
        GameObject deadClone  = Instantiate(deathEffect, transform.position, Quaternion.identity);

        //moving to the empty gameobject to be respawned
        deadClone.transform.parent = deadEnemyClonelist;

        //removing enemy object from the scene after the explosion
        Destroy(gameObject, .3f);
    }
    
}
