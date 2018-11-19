using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Test : MonoBehaviour
{
    public int hitPoints;
    public int lives;
    public float timeToDie;
    public GameObject spawn;
    private int maxHealth;
    public enum Type { CHOCOLATE, MARSHMALLOW, PEPPERMINT };
    public Type healthType;
    public enum PlayerType { ENEMY, PLAYER };
    public PlayerType playerType;

    public GameObject particle;

    // Use this for initialization
    void Start()
    {
        //maxHealth = hitPoints;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (hitPoints <= 0)
        {
           // StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(timeToDie);
        if (playerType == PlayerType.PLAYER)
        {
            /*hitPoints = maxHealth;
            Debug.Log("I am dead");
            Spawn respawn = spawn.GetComponent<Spawn>();
            lives--;
            respawn.Respawn();*/
        }

        if (playerType == PlayerType.ENEMY)
        {
            /*Instantiate(particle, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            gameObject.SetActive(false);*/
        }
    }
    public int HitPoints
    {
        get { return hitPoints; }
        set
        {
            ///hitPoints += value;
            if (hitPoints > maxHealth)
            {
                //hitPoints = maxHealth;
            }
        }
    }

    public GameObject Spawn
    {
        get { return spawn; }
        set
        {
            //spawn = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Projectile otherProjectile = collision.gameObject.GetComponent<Projectile>();
            if (playerType == PlayerType.ENEMY && otherProjectile.playerType == Projectile.PlayerType.PLAYER)
            {
                //hitPoints -= otherProjectile.Damage;
            }
            if (playerType == PlayerType.PLAYER && otherProjectile.playerType == Projectile.PlayerType.PLAYER)
            {
                //Debug.Log("Player Bullet is colliding with Player");
            }
            // Destroy(otherProjectile.gameObject);
        }

        if (collision.gameObject.tag == "Player" && playerType == Test.PlayerType.ENEMY)
        {
            /*hitPoints = 0;
            StartCoroutine(Death());*/
        }

    }

    /*
                     if (hitPoints == 0 || hitPoints <= 0)
                {
                    ClearLog();
                    Debug.Log("HEllO!!!!!!");
                }
                
    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
     */



}