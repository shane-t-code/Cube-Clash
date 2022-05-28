using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    public ParticleSystem destroyParticles;
    public static List<GameObject> enemies = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {   
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
            var liveEnemies = enemies.Where(c => c != null).ToList();
            foreach (var enemy in liveEnemies)
            {
                Instantiate(destroyParticles, enemy.transform.position, enemy.transform.rotation);
                Destroy(enemy);
            }
            return;
        }
        enemies.Add(Instantiate(spawnee, transform.position, transform.rotation));
    }
}