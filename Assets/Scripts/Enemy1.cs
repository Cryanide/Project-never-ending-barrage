using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Rigidbody2D bulletProjectile;
    public Transform target;
    public GameObject eGun;

    public Character character;

    public float shootDelay;
    public float MoveSpeed;

    //int health = 1;

    void Start()
    {
        InvokeRepeating("FireBullets", 1.0f, shootDelay);
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // aims at the player
        this.transform.up = target.position - this.transform.position;
        if (character.lives < 0)
        {
            CancelInvoke("FireBullets");
        }

        // moves to the player slowly
        if (character.lives > 0) transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);
        else transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
    }

    void FireBullets()
    {
        Rigidbody2D bullet;
        if (character.lives > 0)
        {
            bullet = Instantiate(bulletProjectile, eGun.transform.position, eGun.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 10);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MainCamera")
        {
            //Destroy(this.gameObject);
        }

        if (col.tag == "PlayerBullets")
        {
            //health -= 1;

        }
    }
}

