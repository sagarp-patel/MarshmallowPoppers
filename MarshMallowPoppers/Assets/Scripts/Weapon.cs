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
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(projectile, spawnPos, Quaternion.identity);
       
    }
}
