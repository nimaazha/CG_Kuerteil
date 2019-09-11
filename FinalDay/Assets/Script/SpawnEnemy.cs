using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    /*
     * this class will help to insantiate enemy object in the scene
     * this must be attached to a collider so if the player enters the collider
     * will be instansiated an enemy in the defined spawnpoint
     */

    public GameObject enemyObject;

    public Transform spawnPosition;

    public float spawnTheNextEnemyTime =  20.0f; 

    public float toBeAliveTime = 0.0f;

    int counter;

    public int numberOfEnemyToSpawn;

    void OnTriggerEnter(Collider collider)
    {
        counter = 0;
        InvokeRepeating("SpawnTheEnemy", toBeAliveTime, spawnTheNextEnemyTime);
    }

    void SpawnTheEnemy()
    {
     
        if (counter < numberOfEnemyToSpawn)
        {
            Instantiate(enemyObject, spawnPosition.position, spawnPosition.rotation);
        }

        counter++;
    }

}
