using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ScoreSystem : MonoBehaviour
{
    public enum PlayerType { ENEMY, PLAYER };
    public enum Type { CHOCOLATE, MARSHMALLOW, PEPPERMINT };
    public int score;
    public PlayerType playerType;

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
        /* if (collision.gameObject.tag == "Enemy")
          {
             Health healthstatus = collision.gameObject.GetComponent<Health>();
             //score = score  + 5;
             Debug.Log("Hello!!!!!!!!!" + score.ToString());
          }*/
        if (collision.gameObject.tag == "Projectile")
        {
            Projectile otherProjectile = collision.gameObject.GetComponent<Projectile>();
            if (playerType == PlayerType.ENEMY && otherProjectile.playerType == Projectile.PlayerType.PLAYER)
            {
                //ClearLog();
                //Debug.Log("HEllO!!!!!!");
            }
            if (playerType == PlayerType.PLAYER && otherProjectile.playerType == Projectile.PlayerType.PLAYER)
            {

            }
            else
            {
               //ClearLog();
            }

            if (collision.gameObject.tag == "Player" && playerType == ScoreSystem.PlayerType.ENEMY)
            {
                //ClearLog();
                Debug.Log("HEllO TO YOU TOO!!!!!!");
            }
        }
    }

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    /*
    public void IsDestroyed(enemyobject)
    {
        return enemyobject == null && !ReferenceEquals(enemyobject, null);
    }*/
}
