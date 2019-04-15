using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    /*
     * our first special enemy
     * shoots in a sprial patteren
     * created by rox
     */

    public Rigidbody2D bulletProjectile;    //
    public Transform target;                //
    public GameObject eGun1;                //
    public GameObject eGun2;                //
    public GameObject eGun3;                //  there's probably a better way to do this.. but hey, it works
    public GameObject eGun4;                //
    public GameObject eGun5;                //
    public GameObject eGun6;                //
    public GameObject eGun7;                //
    public GameObject eGun8;                //

    [HideInInspector]
    public Transform centrePoint;           



    public Character character;             // gets the player script on the player

    public float shootDelay;
    public float MoveSpeed;

    int health = 30;                        // big boys health

    void Start()
    {
        centrePoint = this.transform;   // moves the centrepoint object with the ship
        InvokeRepeating("FireBullets", 1.0f, shootDelay); // shoots the bullet every X seconds after one second of being spawned
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>(); // finds the player, gets the script
        target = GameObject.FindGameObjectWithTag("Player").transform; // gets the player position
    }

    void Update()
    {
        // nothing is needed here
    }

    void FixedUpdate()
    {
        // moves this ship 0.8 units every time FixedUpdate is called
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.8f, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (character.lives < 0)
            // if the player is dead, stop shooting
            CancelInvoke("FireBullets");
    }

    void FireBullets()
    {
        // again... there's probably a better way to do this
        Rigidbody2D bullet;
        bullet = Instantiate(bulletProjectile, eGun1.transform.position, eGun1.transform.rotation);
        bullet = Instantiate(bulletProjectile, eGun2.transform.position, eGun2.transform.rotation);
        bullet = Instantiate(bulletProjectile, eGun3.transform.position, eGun3.transform.rotation);
        bullet = Instantiate(bulletProjectile, eGun4.transform.position, eGun4.transform.rotation);
        bullet = Instantiate(bulletProjectile, eGun5.transform.position, eGun5.transform.rotation);
        bullet = Instantiate(bulletProjectile, eGun6.transform.position, eGun6.transform.rotation);
        bullet = Instantiate(bulletProjectile, eGun7.transform.position, eGun7.transform.rotation);
        bullet = Instantiate(bulletProjectile, eGun8.transform.position, eGun8.transform.rotation);
    }
}
