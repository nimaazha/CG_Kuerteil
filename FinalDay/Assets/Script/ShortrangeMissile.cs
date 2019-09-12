using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShortrangeMissile : MonoBehaviour
{
    /*
     * this class makes behaviour of a rocket being launched if the player is in his range of sight
     * it works in the short range and it will be shot to the direction that player has been seen.
     * it does not follow the player but it tries to be exploded near of player to hit him with his particles
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

    //the strength of explosion
    public float powerOfExplosion = 10.0f;

    //the radius to the explosion
    public float radius = 20.0f;

    bool isTrue = false;

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

    void FixedUpdate()
    {
        Detonate(isTrue);
    }

    private void ShotTheRocket()
    {
        transform.position += transform.forward * 150 * Time.deltaTime;
        distanceTravelled = Vector3.Distance(transform.position, latestPosition);
        if (distanceTravelled > 150)
        {
            MakeExplosion();
        }
    }

    void OnParticleCollision(GameObject other)
    {
        MakeExplosion();
        ScoreTable.scores += 10;
    }

    void Detonate(bool isTrue)
    {
        if (isTrue)
        {
            Vector3 expPosition = transform.position;
            Collider[] colliders = Physics.OverlapSphere(expPosition, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.gameObject.tag == "Player")
                {
                    targetPlayer.SendMessage("BeingHit");
                }
            }
        }

    }

    void MakeExplosion()
    {
        //this will instantiate the deathEffect of every enemy object as it dies
        //transform.position locates the enemy and Quaternion.identity to avoid rotation
        GameObject deadClone = Instantiate(deathEffect, transform.position, Quaternion.identity);

        //moving to the empty gameobject to be respawned
        deadClone.transform.parent = deadEnemyClonelist;

        //removing enemy object from the scene after the explosion
        Destroy(gameObject, .3f);

        Detonate(true);
    }
}
