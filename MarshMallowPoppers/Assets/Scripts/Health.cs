﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject heartobject1;
    public GameObject heartobject2;
    public GameObject heartobject3;
    public GameObject GameOver;
    public GameObject DisableUI;

    public Text displayhealth;
    public Image HealthBarImage;
    public float ratio;

    public GameObject particle;

    //Use this for initialization
    void Start()
    {
        maxHealth = hitPoints;
        ratio = maxHealth / maxHealth;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        displayhealth.text = "Health: " + hitPoints.ToString();
        HealthBarImage.rectTransform.localScale = new Vector3(ratio, 1.0f, 1.0f);
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
            ratio = 1;
            Debug.Log("I am dead");
            Spawn respawn = spawn.GetComponent<Spawn>();
            lives--;
            if(lives == 3)
            {
                heartobject1.SetActive(true);
                heartobject2.SetActive(true);
                heartobject3.SetActive(true);
            }
            else if (lives == 2)
            {
                heartobject1.SetActive(true);
                heartobject2.SetActive(true);
                heartobject3.SetActive(false);
            }
            else if (lives == 1)
            {
                heartobject1.SetActive(true);
                heartobject2.SetActive(false);
                heartobject2.SetActive(false);
            }
            else if (lives <= 0)
            {
                heartobject1.SetActive(false);
                heartobject2.SetActive(false);
                heartobject3.SetActive(false);
                GameOver.SetActive(true);
                DisableUI.SetActive(false);
                Time.timeScale = 0f;
            }
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

        if (collision.gameObject.tag == "HealthPack") {
            hitPoints += 10;
            Destroy(collision.gameObject);
        }

    }
}