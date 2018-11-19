using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    public GameObject bullet;
    public GameObject enemyobject;
    public int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile" && collision.gameObject.tag == "Player")
         {
            Projectile otherProjectile = collision.gameObject.GetComponent<Projectile>();
            //score = score  + 5;
            Debug.Log("Hello!!!!!!!!!" /*+ score.ToString()*/);
         }
    }
    /*
    public void IsDestroyed(enemyobject)
    {
        return enemyobject == null && !ReferenceEquals(enemyobject, null);
    }*/
}
