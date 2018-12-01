using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public AudioSource HealthPickupSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject begin = GameObject.Find("Player");
            Health callfunction = (Health)begin.GetComponent(typeof(Health));
            callfunction.IncreaseHealth();
            HealthPickupSound.Play();
            Destroy(this.gameObject);
        }
    }
}







