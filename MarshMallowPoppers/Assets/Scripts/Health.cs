using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hitPoints;
    public int lives;
    public float timeToDie;
    public GameObject spawn;
    private int maxHealth;
    public enum Type { CHOCOLATE, MARSHMALLOW, PEPPERMINT};
    public Type healthType;
    public enum PlayerType { ENEMY, PLAYER};
    public PlayerType playerType;

    public GameObject particle;

    // Use this for initialization
    void Start()
    {
        maxHealth = hitPoints;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (hitPoints <= 0 )
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(timeToDie);
        if (playerType == PlayerType.PLAYER) {
            hitPoints = maxHealth;
            Debug.Log("I am dead");
            Spawn respawn = spawn.GetComponent<Spawn>();
            lives--;
            respawn.Respawn();
        }

        if (playerType == PlayerType.ENEMY)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    public int HitPoints
    {
        get { return hitPoints; }
        set
        {
            hitPoints += value;
            if (hitPoints > maxHealth)
            {
                hitPoints = maxHealth;
            }
        }
    }

    public GameObject Spawn
    {
        get { return spawn; }
        set
        {
            spawn = value;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile" )
        {
            Projectile otherProjectile = collision.gameObject.GetComponent<Projectile>();
            Debug.Log("I am colliding with another object!");
            if (playerType == PlayerType.ENEMY && otherProjectile.playerType == Projectile.PlayerType.PLAYER) {
                hitPoints -= otherProjectile.Damage;
                if (hitPoints == 0 || hitPoints <= 0)
                {
                    GameObject begin = GameObject.Find("Player");
                    ScoreSystem callfunction = (ScoreSystem)begin.GetComponent(typeof(ScoreSystem));
                    callfunction.UpdateScore();
                }
            }
            if (playerType == PlayerType.PLAYER && otherProjectile.playerType == Projectile.PlayerType.PLAYER) {
                Debug.Log("Player Bullet is colliding with Player");
                
            }
            Destroy(otherProjectile.gameObject);
        }

        if (collision.gameObject.tag == "Player" && playerType == Health.PlayerType.ENEMY) {
            hitPoints = 0;
            StartCoroutine(Death());
        }

    }
}