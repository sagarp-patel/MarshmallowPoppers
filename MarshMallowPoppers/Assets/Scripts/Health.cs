using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float hitPoints;
    public int lives;
    public float timeToDie;
    public GameObject spawn;
    private float maxHealth;
    public enum Type { CHOCOLATE, MARSHMALLOW, PEPPERMINT};
    public Type healthType;
    public enum PlayerType { ENEMY, PLAYER};
    public PlayerType playerType;
    public GameObject GameOver;
    public GameObject DisableUI;
    public Text LivesTextObject;

    public Text displayhealth;
    public Image HealthBarImage;
    public float ratio;

    public GameObject particle;

    //Use this for initialization
    void Start()
    {
        maxHealth = hitPoints;
        if(playerType == PlayerType.PLAYER)
        {
            ratio = 1;
            LivesTextObject.text = lives.ToString();
            HealthBarImage.rectTransform.localScale = new Vector3(ratio, 1, 1);
        }
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
            ratio = 1;
            Debug.Log("I am dead");
            Spawn respawn = spawn.GetComponent<Spawn>();
            lives--;
            LivesTextObject.text = lives.ToString();
            if (lives <= 0)
            {
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

    public float HitPoints
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

        if (playerType == PlayerType.PLAYER)
        {
            if(HitPoints > maxHealth)
            {
                ratio = 1;
                displayhealth.text = "Health: " + hitPoints.ToString();
                HealthBarImage.rectTransform.localScale = new Vector3(ratio, 1.0f, 1.0f);
            }
            else
            {
                ratio = hitPoints / maxHealth;
                displayhealth.text = "Health: " + hitPoints.ToString();
                HealthBarImage.rectTransform.localScale = new Vector3(ratio, 1.0f, 1.0f);
            }
        }

        if (collision.gameObject.tag == "Player" && playerType == Health.PlayerType.ENEMY) {
            hitPoints = 0;
            StartCoroutine(Death());
        }

        if (collision.gameObject.tag == "HealthPack" && playerType == PlayerType.PLAYER) {
            hitPoints += 10;
            Destroy(collision.gameObject);
            if (HitPoints > maxHealth)
            {
                ratio = 1;
                displayhealth.text = "Health: " + hitPoints.ToString();
                HealthBarImage.rectTransform.localScale = new Vector3(ratio, 1.0f, 1.0f);
            }
            else
            {
                ratio = hitPoints / maxHealth;
                displayhealth.text = "Health: " + hitPoints.ToString();
                HealthBarImage.rectTransform.localScale = new Vector3(ratio, 1.0f, 1.0f);
            }
        }
    }
}