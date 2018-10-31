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
    [SerializeField] [Range(0, 50)] private float speed = 0;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        moveRight = KeyCode.D;
        moveLeft  = KeyCode.A;
        jump      = KeyCode.Space;
        fire      = KeyCode.Mouse0;
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Attack();
        //Jump();
	}

    void Movement() {

        if (Input.GetKey(moveRight))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(moveLeft)) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(jump) && isGrounded == true)
        {
            Debug.Log("SpaceBar is pressed", gameObject);
            Jump();
        }
    }

    void Attack() {

    }

    void Jump() {
        Debug.Log("Jump button is pressed", gameObject);
        //isGrounded = false;
        rigidBody.AddForce(Vector2.up * 250.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision has Happened", gameObject);
        Debug.Log(collision.gameObject.tag,gameObject);
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}