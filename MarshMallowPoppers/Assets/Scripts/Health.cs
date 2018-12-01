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

    public AudioSource Explosion;
    public AudioSource GameOverSound;
    public AudioSource PlayerDeathSound;

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

        if (playerType == PlayerType.PLAYER)
        {
            LivesTextObject.text = lives.ToString();
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
            PlayerDeathSound.Play();
            if (lives < 0)
            {
                GameOver.SetActive(true);
                DisableUI.SetActive(false);
                GameOverSound.Play();
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

    public void IncreaseLives()
    {
        lives += 1;
        if (lives > 99)
        {
            lives = 99;
        }
    }

    public void IncreaseHealth()
    {
        hitPoints += 10;
        if (hitPoints > maxHealth)
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
        GameObject begin = GameObject.Find("Player");
        ScoreSystem callfunction = (ScoreSystem)begin.GetComponent(typeof(ScoreSystem));

        GameObject begin_again = GameObject.FindWithTag("Timer");
        CountDownTimer callfunction_again = (CountDownTimer)begin_again.GetComponent(typeof(CountDownTimer));

        if (collision.gameObject.tag == "Projectile" )
        {
            Projectile otherProjectile = collision.gameObject.GetComponent<Projectile>();
            Debug.Log("I am colliding with another object!");
            if (playerType == PlayerType.ENEMY && otherProjectile.playerType == Projectile.PlayerType.PLAYER) {
                switch (otherProjectile.projectileType) {
                    case Projectile.ProjectileType.MARSHMALLOW:
                        reduceHealth(0, otherProjectile.damage);
                        break;
                    case Projectile.ProjectileType.CHOCOLATE:
                        reduceHealth(1, otherProjectile.damage);
                        break;
                    case Projectile.ProjectileType.PEPPERMINT:
                        reduceHealth(2, otherProjectile.damage);
                        break;
                }
                //hitPoints -= otherProjectile.Damage;
                if (hitPoints == 0 || hitPoints <= 0)
                {
                    callfunction.UpdateScore();   
                    callfunction_again.AddTime();
                    Explosion.Play();
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
            Explosion.Play();
        }
    }

    private void reduceHealth(int type, int damage) {

        // type 
        // -0 = marhsmallow
        // -1 = Chocolate
        // -2 = Peppermint
        // Peppermint > Chocolate
        // Chocolate > Marshmallow
        // Marshmallow > Peppermint

        if (healthType == Type.MARSHMALLOW) {
            switch (type) {
                case 0: // Marshmallow neutral damage
                    hitPoints -= damage;
                    break;
                case 1: // Chocolate Does more damage
                    hitPoints -= (damage + (damage * .25f));
                    break;
                case 2: // Peppermint does less damage
                    hitPoints -= (damage - (damage * .75f));
                    break;
            }
        }

        if (healthType == Type.CHOCOLATE)
        {
            switch (type)
            {
                case 0: // Marsmallow does less damage
                    hitPoints -= (damage - (damage * .75f));
                    break;
                case 1: // Chocolate does neutral damage
                    hitPoints -= damage;
                    break;
                case 2: // Peppermint does more damage
                    hitPoints -= (damage + (damage * .25f));
                    break;
            }
        }

        if (healthType == Type.PEPPERMINT)
        {
            switch (type)
            {
                case 0: // Marsmallow does more damage
                    hitPoints -= (damage + (damage * .25f));
                    break;
                case 1: // Chocolate does less damage
                    hitPoints -= (damage - (damage * .75f));
                    break;
                case 2: // Peppermint does neutral damage
                    hitPoints -= damage;
                    break;
            }
        }
    }
}