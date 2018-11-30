using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {

    public AudioSource CoinSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        transform.DetachChildren();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject begin = GameObject.Find("Player");
            ScoreSystem callfunction = (ScoreSystem)begin.GetComponent(typeof(ScoreSystem));
            callfunction.FoundCoin();
            CoinSound.Play();
            Destroy(this.gameObject);
        }
    }
}
