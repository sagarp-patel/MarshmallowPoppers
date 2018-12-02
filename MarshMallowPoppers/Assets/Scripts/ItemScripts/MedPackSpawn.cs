using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPackSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] MedPack;
    int randomSpawnPoint, randomCoins;
    public static bool spawnAllowed;

    // Use this for initialization
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0f, 5f);
    }
    void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomCoins = Random.Range(0, MedPack.Length);
            Instantiate(MedPack[randomCoins], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);
        }
    }
}

