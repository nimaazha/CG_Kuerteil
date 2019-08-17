using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light testLight;
    public float timeToWait;
    void Start()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);
            testLight.enabled = !testLight.enabled;
        }
    }
}