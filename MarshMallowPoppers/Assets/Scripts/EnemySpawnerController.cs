using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    /* public Transform[] spawnPoints;
     public GameObject[] monsters;
     int randomSpawnPoint, randomMonster;
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
              for (int i = 0; i < monsters.Length;i++)
              {
                  monsters[randomMonster].SetActive(true);
                  // Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
                  //   Quaternion.identity);
                  //Instantiate(monsters[0], spawnPoints[randomSpawnPoint].position,
                  // Quaternion.identity);
                 // monsters[randomMonster].SetActive(true);
              }
             randomSpawnPoint = Random.Range(0, spawnPoints.Length);
             randomMonster = Random.Range(0, monsters.Length);
           //  monsters[randomMonster].SetActive(true);
         }
     }*/
    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;

    // Use this for initialization
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0f, 1f);
    }

    void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);
        }
    }
}

