using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public bool EnemyBullet;
    public bool circleForm; 
    public Character character;
    public Rigidbody2D ShipCentre;
    public Rigidbody2D enemyShip;

    bool InsidePlayArea;

    // Start is called before the first frame update
    void Start()
    {
        if (!circleForm)
            Destroy(this.gameObject, 3.0f);
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if (character == null) Destroy(this.gameObject); // should a bullet get spawned AFTER the player has died, just delete it, gets rid of errors
    }

    void Update()
    {
        // nothing needed here
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (circleForm)
        {
            // destroys the bullet once the enemy is gone
            if (GameObject.FindGameObjectWithTag("SpecialEnemy") == null) Destroy(this.gameObject);

            // get the Ridgidbody of the centre of the ship (another gameObject)
            ShipCentre = GameObject.FindGameObjectWithTag("ShipCentrePoint").GetComponent<Rigidbody2D>();

            // rotates on the z axis 60 times your current framerate (converted back to ms)
            transform.RotateAround(ShipCentre.position, new Vector3(0, 0, 1), 60 * Time.deltaTime);

            // moves the bullets away from the centre while it moves in a cirlce
            transform.position = Vector2.MoveTowards(transform.position, ShipCentre.position, -10 * Time.deltaTime); 
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (EnemyBullet)
        {
            if (col.gameObject.tag == "Player")
            {
                Destroy(this.gameObject); // yeets the bullet outta here
            }
        }
        else if(!EnemyBullet) // if EnemBullet is false
        {
            if (col.gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject); // yeets the bullet outta here
            }
        }
    }
}
