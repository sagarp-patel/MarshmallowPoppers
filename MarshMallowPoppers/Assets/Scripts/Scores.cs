﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    // public GameObject bulletScore;
    //public int score;
    //public Text displaycoin;

    // Use this for initialization
    void Start () {
       // score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.bulletScore.tag == "Enemy")
        {
            score = score  + 5;
            Debug.Log(score.ToString());
        }*/
        //if (collision.bulletScore.tag == "Enemy")
        //{
        //    score = score  + 5;
        //    Debug.Log(score.ToString());
        //}
        if (collision.gameObject.tag == "Coin")
        {
            GameObject begin = GameObject.Find("Player");
            ScoreSystem callfunction = (ScoreSystem)begin.GetComponent(typeof(ScoreSystem));
            callfunction.FoundCoin();
        }
    }
}
