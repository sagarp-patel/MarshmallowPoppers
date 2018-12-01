using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] coins;
    public Vector3 spawnValues;
    public float spawnWait;
    public int startWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    //public bool stop;
    int randcoin;

	// Use this for initialization
	void Start () {
        StartCoroutine(coinSpawner());
	}
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}
    IEnumerator coinSpawner()
    {
        yield return new WaitForSeconds (startWait);
        while(true)
        {
            randcoin = Random.Range(0,1);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y),1);
            Instantiate(coins[randcoin], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
