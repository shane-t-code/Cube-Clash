using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{
    public Gun gunScript;
    public GameObject Portal;
    public TimedSpawn spawnScript;
    public TimedSpawn spawnScript2;

    // Update is called once per frame
    void Update()
    {
        if (gunScript.Energy >= 100f)
        {
            Portal.SetActive(true);
            spawnScript.stopSpawning = true;
            spawnScript2.stopSpawning = true;

        }
    }
}
