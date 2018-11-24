using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Controller : MonoBehaviour {

    [SerializeField] [Range(0.0f, 10.0f)] private float sensitivity;
	[SerializeField] [Range(0.0f, 10.0f)] private float smoothing;
    public Transform Player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector2(Player.position.x, Player.position.y);
	}
}
