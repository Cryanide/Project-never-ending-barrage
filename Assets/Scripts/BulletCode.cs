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

    // Start is called before the first frame update
    void Start()
    {
        if (!circleForm)
            Destroy(this.gameObject, 3.0f);
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (circleForm)
        {
            if (GameObject.FindGameObjectWithTag("EnemyBoss") == null) Destroy(this.gameObject, 2f);
            ShipCentre = GameObject.FindGameObjectWithTag("ShipCentrePoint").GetComponent<Rigidbody2D>();
            transform.RotateAround(ShipCentre.position, new Vector3(0, 0, 1), 60 * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, ShipCentre.position, -10 * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
            Debug.Log("Camera");
        }

        if (EnemyBullet)
        {
            if (col.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
                character.lives -= 1;
                Debug.Log("PlayerHit");
            }
        }
        else if(!EnemyBullet)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject);
                Debug.Log("EnemyHit");
            }
        }
    }
}
