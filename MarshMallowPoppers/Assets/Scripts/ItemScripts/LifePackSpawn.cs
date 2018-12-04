using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePackSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] LifePack;
    int randomSpawnPoint, randomCoins;
    public static bool spawnAllowed;

    // Use this for initialization
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 20f, 20f);
    }
    void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomCoins = Random.Range(0, LifePack.Length);
            Instantiate(LifePack[randomCoins], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);
        }
    }
}

