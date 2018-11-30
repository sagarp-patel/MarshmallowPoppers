using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour {
    public string newGameLevel;

    //Check if the isTrigger option on th Collider2D is set to true or false
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(newGameLevel);
        }
    }
}
