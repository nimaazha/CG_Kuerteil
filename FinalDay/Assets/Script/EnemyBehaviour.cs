using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    //explosion effect on the player
    public GameObject deathEffect;

    void OnParticleCollision(GameObject other)
    {
        MakeExplosion();
    }

    void MakeExplosion()
    {
        print("Enemy " + gameObject.name + " is Dead");
        deathEffect.SetActive(true);
        Destroy(gameObject, .5f);
    }
}
