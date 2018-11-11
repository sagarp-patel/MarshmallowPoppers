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
}
