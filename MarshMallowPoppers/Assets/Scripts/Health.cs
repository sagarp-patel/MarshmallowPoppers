using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int hitPoints;
    private int maxHitPoints;
    public float timeToDie;
    public GameObject spawn;

    // Use this for initialization
    void Start () {
        maxHitPoints = hitPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Death()
    {
        yield return new WaitForSeconds(timeToDie);

        Destroy(gameObject);
    }

    public int HitPoints
    {
        get { return hitPoints; }
        set
        {
            hitPoints += value;
            if (hitPoints > maxHitPoints)
            {
                hitPoints = maxHitPoints;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Projectile otherProjectile = collision.gameObject.GetComponent<Projectile>();
           hitPoints -= otherProjectile.Damage;
            Destroy(otherProjectile.gameObject);
        }else if(collision.gameObject.tag == "Enemy"){
            hitPoints -= 10;
        }
    }
}
