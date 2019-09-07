using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    /*
     * this class makes behaviour of a rocket being launched if the player is in his range of sight
     */

    public GameObject enemyObject;

    public Transform spawnPosition;

    public float spawnTheNextEnemyTime =  20.0f; 

    public float toBeAliveTime = 0.0f;

    int counter;

    void OnTriggerEnter(Collider collider)
    {
        counter = 0;
        InvokeRepeating("SpawnTheEnemy", toBeAliveTime, spawnTheNextEnemyTime);
    }

    void SpawnTheEnemy()
    {
     
        if (counter < 1)
        {
            Instantiate(enemyObject, spawnPosition.position, spawnPosition.rotation);
        }

        counter++;
    }

}
