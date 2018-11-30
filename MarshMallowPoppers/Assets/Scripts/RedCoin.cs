using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : MonoBehaviour {

    public AudioSource CoinSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject begin = GameObject.Find("Player");
            ScoreSystem callfunction = (ScoreSystem)begin.GetComponent(typeof(ScoreSystem));
            callfunction.FoundGrandCoin();
            CoinSound.Play();
            Destroy(this.gameObject);
        }
    }
}
