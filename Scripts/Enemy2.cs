using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Rigidbody2D bulletProjectile;
    public Transform target;
    public GameObject eGun;

    public Character character;

    public float shootDelay;
    public float MoveSpeed;

    int health = 6;

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
        // if inside play area, face the target (which is the player)
        else this.transform.up = target.position - this.transform.position;

        // moves to the player slowly EDIT: if inside play Area
        if (!character.PlayerHasDied && RulesOfEngagement.InsidePlayArea) transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);

        // if the player has died they stop moving
        else transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
    }

    void FireBullets()
    {   
        Rigidbody2D bullet;
        if (!character.PlayerHasDied && RulesOfEngagement.InsidePlayArea)
        {
            // spawns the bullets at three seperate angles
            bullet = Instantiate(bulletProjectile, eGun.transform.position, eGun.transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.up * 10);

            bullet = Instantiate(bulletProjectile, eGun.transform.position, eGun.transform.rotation);
            bullet.velocity = transform.TransformDirection(new Vector3(3, 10, 0));

            bullet = Instantiate(bulletProjectile, eGun.transform.position, eGun.transform.rotation);
            bullet.velocity = transform.TransformDirection(new Vector3(-3, 10, 0));
        }
    }
}
