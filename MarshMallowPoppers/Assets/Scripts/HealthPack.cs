using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject begin = GameObject.Find("Player");
        Health callfunction = (Health)begin.GetComponent(typeof(Health));
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Picked up Health");
            callfunction.IncreaseLives();
            Destroy(this.gameObject);
            //gameObject.SetActive(false);
        }
    }
}







