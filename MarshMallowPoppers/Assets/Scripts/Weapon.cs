using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Projectile projectile;
    public enum PlayerType { ENEMY, PLAYER };
    public PlayerType playerType;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire() { 
        if (Input.mousePosition.x > transform.position.x) {
            Vector2 spawnPos = new Vector2(transform.position.x + 1, transform.position.y);
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(projectile, spawnPos, rotation);
        }

        if (transform.position.x > Input.mousePosition.x)
        {
            Vector2 spawnPos = new Vector2(transform.position.x - 2, transform.position.y);
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(projectile, spawnPos, rotation);
        }


    }
}
