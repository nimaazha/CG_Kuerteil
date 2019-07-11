using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfdestructionOfClone : MonoBehaviour
{

    /*
     * 
     * this class deletes the clone object remained from dead Enemy
     * this will be attached to the explosionOnEnemy prefab
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

}
