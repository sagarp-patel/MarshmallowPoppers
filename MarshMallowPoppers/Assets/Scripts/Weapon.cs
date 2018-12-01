using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile projectile;
    public enum PlayerType { ENEMY, PLAYER };
    public PlayerType playerType;
    private WaitForSeconds fireRate;
    [SerializeField] [Range(1.0f, 600.0f)] private float rateOfFire;
    private bool allowFire;
    public AudioSource Projectile_Fire;

    // Use this for initialization
    //MarshMallow Weapon

    private void Awake()
    {
        fireRate = new WaitForSeconds(60.0f / rateOfFire);
        allowFire = true;
    }
    /*
    public void Fire() {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x > transform.position.x && mousePosition.x < transform.position.x + .5f)
        {
            if (mousePosition.y > transform.position.y + 1.0f) {
                Debug.Log("mouse Position > transform position");
                Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y + .55f);
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Instantiate(projectile, spawnPos, rotation);
                
            } else if (transform.position.y - 1.0f > mousePosition.y) {
                Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y - .70f);
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Instantiate(projectile, spawnPos, rotation);
            }
        }else if (transform.position.x > mousePosition.x)
        {
            Vector2 spawnPos = new Vector2(transform.position.x - .55f, transform.position.y);
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(projectile, spawnPos, rotation);
        }else if (mousePosition.x > transform.position.x) {
            Debug.Log("mouse Position > transform position");
            Vector2 spawnPos = new Vector2(transform.position.x + .75f, transform.position.y);
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(projectile, spawnPos, rotation);
        }
        
    }
    */
    public IEnumerator Fire()
    {
        float rad = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
        float angle_deg = (180 / Mathf.PI) * rad;
        this.transform.rotation = Quaternion.Euler(0, 0, angle_deg);
        Debug.Log("Reached the Fire Function");
        if (allowFire)
        {
            Projectile_Fire.Play();
            Debug.Log("Firing a Projectile");
            allowFire = false;
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(projectile, gameObject.transform.position, rotation);
            Debug.Log("Fired Projectile now waiting for next one");
            yield return fireRate;
            allowFire = true;
            Debug.Log("Allow Fire now set to true");
        }
    }

    public void setFire(bool allow) {
        allowFire = allow;
    }
}

