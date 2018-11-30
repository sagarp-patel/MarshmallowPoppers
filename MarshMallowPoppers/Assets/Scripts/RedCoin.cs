using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoin : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject begin = GameObject.Find("Player");
            ScoreSystem callfunction = (ScoreSystem)begin.GetComponent(typeof(ScoreSystem));
            callfunction.UpdateGrandCoin();
            Destroy(this.gameObject);
        }
    }
}
