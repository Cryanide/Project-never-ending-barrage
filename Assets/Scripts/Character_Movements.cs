using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movements : MonoBehaviour {

    public int playerSpeed = 10;
    public float playerJumpPower = 10;

    // Use this for initialization
    void Start () {
		
	}


    // Update is called once per frame
    void FixedUpdate () {
        // if you press up or down, you go up or down
        // same thing for left and right
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, Input.GetAxisRaw("Vertical") * playerSpeed);
    }
}
