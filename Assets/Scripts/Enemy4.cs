using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    /*
     * flies across the screen in a upwards curve 
     * fires two collums of bullets going straight down
     * crated by Rox
     */

    public Rigidbody2D bulletProjectile;
    public Transform target;
    public GameObject eGunLeft;
    public GameObject eGunRight;

    public Character character;

    public float shootDelay;
    public float MoveSpeed;

    bool OnTheRightSide = false;
    bool LockDir = false;


    // Universal script for all enemies
    // they have to follow these rules
    // comparable to the 10 commandments
    Enemy_Universal RulesOfEngagement;

    // an int used to figure out which entry point the ship will use
    int EntryPointNumber;

    void Start()
    {
        // shoots bullet every [shootDelay] seconds
        InvokeRepeating("FireBullets", 1.0f, shootDelay);
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // since every enemy requires this script, we can just have look within itself for this
        // in other words, the ship goes soul searching for the scared rules 
        RulesOfEngagement = this.gameObject.GetComponent<Enemy_Universal>();

        // this is why i need to find the entry points in the awake method in the universal script
        EntryPointNumber = Random.Range(0, RulesOfEngagement.EntryPoints.Length);
    }

    void Update()
    {
        // nothing needed here
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // aims at the player EDIT: if inside the play area
        if (!RulesOfEngagement.InsidePlayArea)
        {
            // faces entry point
            this.transform.up = RulesOfEngagement.EntryPoints[EntryPointNumber].transform.position - this.transform.position;

            //moves to entry point
            transform.position = Vector2.MoveTowards(transform.position, RulesOfEngagement.EntryPoints[EntryPointNumber].transform.position, 20 * Time.deltaTime);
        }

        else transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 180);

        // moves to the opposite side of the screen
        if (!character.PlayerHasDied && RulesOfEngagement.InsidePlayArea)
        {
            if(OnTheRightSide) gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-6f, -200f * Time.deltaTime);
            else gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(6f, -200f * Time.deltaTime);
        }

        // if inside play area, face downwards
        else transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
    }

    void FireBullets()
    {
        Rigidbody2D bullet;
        if (!character.PlayerHasDied && RulesOfEngagement.InsidePlayArea)
        {
            // merely shoots the bullet
            bullet = Instantiate(bulletProjectile, eGunLeft.transform.position, eGunLeft.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 5);
            bullet = Instantiate(bulletProjectile, eGunLeft.transform.position, eGunLeft.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 8);
            bullet = Instantiate(bulletProjectile, eGunLeft.transform.position, eGunLeft.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 11);
            bullet = Instantiate(bulletProjectile, eGunLeft.transform.position, eGunLeft.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 14);
            bullet = Instantiate(bulletProjectile, eGunLeft.transform.position, eGunLeft.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 17);
            bullet = Instantiate(bulletProjectile, eGunRight.transform.position, eGunRight.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 5);
            bullet = Instantiate(bulletProjectile, eGunRight.transform.position, eGunRight.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 8);
            bullet = Instantiate(bulletProjectile, eGunRight.transform.position, eGunRight.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 11);
            bullet = Instantiate(bulletProjectile, eGunRight.transform.position, eGunRight.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 14);
            bullet = Instantiate(bulletProjectile, eGunRight.transform.position, eGunRight.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 17);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "RightSide" && !LockDir)
        {
            OnTheRightSide = true;
            LockDir = true;
        }
        if (col.gameObject.tag == "LeftSide" && !LockDir) LockDir = true;
    }
}

