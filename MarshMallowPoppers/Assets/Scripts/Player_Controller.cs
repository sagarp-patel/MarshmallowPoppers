using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    private KeyCode moveRight;
    private KeyCode moveLeft;
    private KeyCode jump;
    private KeyCode changeWeapon;
    private KeyCode fire;
    private KeyCode pause;
    private Rigidbody2D rigidBody;
    private bool isGrounded;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        moveRight = KeyCode.D;
        moveLeft  = KeyCode.A;
        jump      = KeyCode.Space;
        fire      = KeyCode.Mouse0;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Attack();
        Jump();
	}

    void Movement() {

    }

    void Attack() { }

    void Jump() { }
}