using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform player;
    public GameObject projectile;

    //private float timeBShots;
    //public float startTimeBShots;

    public float direction;
    public Vector2 scale;
    bool facingRight;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
        direction = -1.0f;
        //timeBShots = startTimeBShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (transform.position.x < -10.0f)
        {
            direction = 1.0f;
        }
        else if (transform.position.x > 10.0f)
        {
            direction = -1.0f;
        }

        //if (timeBShots <= 0)
        //{
        //    //Instantiate(projectile, transform.position, Quaternion.identity);
        //    //timeBShots = startTimeBShots;
        //}
        //else
        //{
        //    //timeBShots -= Time.deltaTime;
        //}
    }

    void EnemyFace()
    {
        if (direction > 0)
        {
            facingRight = true;
        }
        else if (direction < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && scale.x < 0) || ((facingRight) && (scale.x > 0)))
        {
            scale.x += -1;
        }
        transform.localScale = scale;
    }

    void JumpTrigger(Collider2D coll)
    {
        switch(coll.tag)
        {
            case "Ground":
                rb.AddForce(Vector2.up * 550.0f);
                break;
        }
    }
}