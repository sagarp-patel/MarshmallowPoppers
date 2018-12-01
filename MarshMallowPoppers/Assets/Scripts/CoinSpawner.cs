using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] coins;
    int randomSpawnPoint, randomCoins;
    public static bool spawnAllowed;

    // Use this for initialization
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0f, 3f);
    }
    void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomCoins = Random.Range(0, coins.Length);
           Instantiate(coins[randomCoins], spawnPoints[randomSpawnPoint].position,
               Quaternion.identity);
        }
    }
}

