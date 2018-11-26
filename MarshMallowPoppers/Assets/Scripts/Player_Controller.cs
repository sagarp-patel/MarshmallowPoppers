using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    private KeyCode moveRight;
    private KeyCode moveLeft;
    private KeyCode jump;
    private KeyCode changeWeapon;
    private KeyCode fire;
    private KeyCode pause;
    private Rigidbody2D rigidBody;
    private bool isGrounded;
    public bool allowFire;
    public Projectile projectile;
    [SerializeField] [Range(0, 50)] private float speed = 0;
    private Weapon weapon;
    public Animator animator;
    private float movement_speed; //Created for Animator

    float fallZone = -10f;
    Vector3 InitPos;  //initial position of player
    // Use this for initialization
    void Start ()
    {
        InitPos = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        moveRight = KeyCode.D;
        moveLeft  = KeyCode.A;
        jump      = KeyCode.Space;
        fire      = KeyCode.Mouse0;
        isGrounded = true;
        weapon = GetComponentInChildren<Weapon>();
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(),gameObject.GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float rad = Mathf.Atan2(Input.mousePosition.y - transform.position.y,Input.mousePosition.x - transform.position.x);
        //float angle_deg = (180/Mathf.PI)*rad;
        //this.transform.rotation = Quaternion.Euler(0, 0, angle_deg);
        movement_speed = 0.0f;
        Movement();
        animator.SetFloat("Speed", movement_speed);

        if (transform.position.y < fallZone) 
        {
            transform.position = InitPos;
        }
	}

    void Movement()
    {
        Health health = gameObject.GetComponent<Health>();
        if (health.HitPoints >= 0)
        {
            if (Input.GetKey(moveRight))
            {
                movement_speed = speed;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(moveLeft))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                movement_speed = speed * -1.0f;
            }

            if (Input.GetKeyDown(jump) && isGrounded == true)
            {
                Debug.Log("SpaceBar is pressed", gameObject);
                Jump();
                //Instantiate(projectile, transform.position, Quaternion.identity);
            }

            if (Input.GetMouseButton(0))
            {
                //Instantiate(projectile, transform.position, Quaternion.identity);
                Attack();
            }
        }
    }

    void Attack()
    {

        //Instantiate(projectile, gameObject.transform.position, Quaternion.identity);

        weapon.Fire();
    }

    void Jump()
    {
        Debug.Log("Jump button is pressed", gameObject);
        isGrounded = false;
        rigidBody.AddForce(Vector2.up * 400.0f);
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision has Happened", gameObject);
        Debug.Log(collision.gameObject.tag,gameObject);
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Health")
        {
            Health hitPoints = gameObject.GetComponent<Health>();
            hitPoints.hitPoints += 10;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Health hitPoints = gameObject.GetComponent<Health>();
            Health ratio = gameObject.GetComponent<Health>();
            hitPoints.hitPoints -= 10;
            ratio.ratio -= 0.10f;
            /*if (ratio.ratio <= 0.0f)
            {
                ratio.ratio = 1;
            }*/
        }

        if (collision.gameObject.tag == "Lives")
        {
            Health lives = gameObject.GetComponent<Health>();
            lives.lives += 1;
        }

        if (collision.gameObject.tag == "Cloud")
        {
            isGrounded = true;
            yield return new WaitForSeconds(1);
            Destroy(collision.gameObject);
            
        }

    }
}