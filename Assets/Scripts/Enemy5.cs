using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MonoBehaviour
{
    /*
     * fires a spray of 6 bullets downwards in a semi-circle shape
     * slowly descends downward
     * 
     * crated by Rox
     */

    public Rigidbody2D bulletProjectile;
    public Transform target;
    public GameObject eGun1;
    public GameObject eGun2;
    public GameObject eGun3;
    public GameObject eGun4;
    public GameObject eGun5;
    public GameObject eGun6;

    public Character character;

    public float shootDelay;
    public float MoveSpeed;


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

        // moves to the player slowly EDIT: if inside play Area
        if (!character.PlayerHasDied && RulesOfEngagement.InsidePlayArea) gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2f);

        // if inside play area, face the target (which is the player)
        else transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
    }

    void FireBullets()
    {
        Rigidbody2D bullet;
        if (!character.PlayerHasDied && RulesOfEngagement.InsidePlayArea)
        {
            // merely shoots the bullet
            bullet = Instantiate(bulletProjectile, eGun1.transform.position, eGun1.transform.rotation);
            bullet.velocity = transform.TransformDirection(new Vector3(-4.77f, 1.5f, 0f));
            bullet = Instantiate(bulletProjectile, eGun2.transform.position, eGun2.transform.rotation);
            bullet.velocity = transform.TransformDirection(new Vector3(-4.08f, 2.9f, 0f));
            bullet = Instantiate(bulletProjectile, eGun4.transform.position, eGun4.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 5);
            bullet = Instantiate(bulletProjectile, eGun5.transform.position, eGun5.transform.rotation);
            bullet.velocity = transform.TransformDirection(new Vector3(4.08f, 2.9f, 0f));
            bullet = Instantiate(bulletProjectile, eGun6.transform.position, eGun6.transform.rotation);
            bullet.velocity = transform.TransformDirection(new Vector3(4.77f, 1.5f, 0f));
        }

    }
}

