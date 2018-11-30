using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour {

    public Collider2D coll;
    public Collision2D collision;
    public string newGameLevel;

    //Check if the isTrigger option on th Collider2D is set to true or false
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(newGameLevel);
        }
    }
}
