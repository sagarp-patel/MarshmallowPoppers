using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour {

    public Collider2D coll;
    public Collision2D collision;
    public string newGameLevel;

    //Check if the isTrigger option on th Collider2D is set to true or false

    void OnCollisionEnter2D(Collision2D collision)
    {
        ClearLog();
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("Hello!!!!!!!!!!!!!!!");
            SceneManager.LoadScene(newGameLevel);
        }
    }

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
