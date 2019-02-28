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

    void Start()
    {
        InvokeRepeating("FireBullets", 1.0f, shootDelay);
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // aims at the player
        this.transform.right = target.position - this.transform.position;
        if(character.lives < 0)
        {
            CancelInvoke("FireBullets");
        }

        // moves to the player slowly
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime);
    }

    void FireBullets()
    {
        Rigidbody2D bullet;
        bullet = Instantiate(bulletProjectile, eGun.transform.position, eGun.transform.rotation);
        bullet.velocity = transform.TransformDirection(Vector3.right * 10);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MainCamera")
        {
            Destroy(this.gameObject);
            Debug.Log("yes");
        }

        if (col.tag == "PlayerBullets")
        {
            Destroy(this.gameObject);
            Debug.Log("yes");
        }
    }
}
