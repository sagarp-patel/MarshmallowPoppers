using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed;
    public int damage;
    public float secondsToDestroy;
    public WaitForSeconds time;

	// Use this for initialization
	void Start () {
        time = new WaitForSeconds(0.01f);
        StartCoroutine(Trajectory());
        StartCoroutine(SelfDestruct(secondsToDestroy));
    }

    IEnumerator Trajectory()
    {
        yield return time;

        gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);

        StartCoroutine(Trajectory());
    }

    IEnumerator SelfDestruct(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }

    public int Damage {
        get { return damage; }
        set { damage = value; }
    }
}
