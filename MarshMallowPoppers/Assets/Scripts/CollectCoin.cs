using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {
    public Collision2D other1;
    public Collider2D other;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnDestroy()
    {
        transform.DetachChildren();
    }
    void OnCollisionEnter2D(Collision2D other1)
    {
        if (other1.gameObject.name=="Player")
        {
            Debug.Log("this is destroyer");

            Destroy(this.gameObject);
        }
    }
}
