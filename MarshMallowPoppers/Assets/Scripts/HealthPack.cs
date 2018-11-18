using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Picked up Health");
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}







