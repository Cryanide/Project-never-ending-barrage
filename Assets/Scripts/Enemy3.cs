using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public Rigidbody2D bulletProjectile;
    public Transform target;
    public GameObject eGun1;
    public GameObject eGun2;
    public GameObject eGun3;
    public GameObject eGun4;
    public GameObject eGun5;
    public GameObject eGun6;
    public GameObject eGun7;
    public GameObject eGun8;

    public Transform centrePoint;



    public Character character;

    public float shootDelay;
    public float MoveSpeed;

    int health = 30;

    void Start()
    {
        centrePoint = this.transform;
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
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.8f, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (character.lives < 0)
        {
            CancelInvoke("FireBullets");
        }
    }

    void FireBullets()
    {
        Rigidbody2D bullet;
        bullet = Instantiate(bulletProjectile, eGun1.transform.position, eGun1.transform.rotation);
        //bullet.velocity = transform.TransformDirection(Vector3.up * 5);
        bullet = Instantiate(bulletProjectile, eGun2.transform.position, eGun2.transform.rotation);
        //bullet.velocity = transform.TransformDirection(Vector3.up * 5);
        bullet = Instantiate(bulletProjectile, eGun3.transform.position, eGun3.transform.rotation);
        //bullet.velocity = transform.TransformDirection(Vector3.up * 5);
        bullet = Instantiate(bulletProjectile, eGun4.transform.position, eGun4.transform.rotation);
        //bullet.velocity = transform.TransformDirection(Vector3.up * 5);
        bullet = Instantiate(bulletProjectile, eGun5.transform.position, eGun5.transform.rotation);
        //bullet.velocity = transform.TransformDirection(Vector3.up * 5);
        bullet = Instantiate(bulletProjectile, eGun6.transform.position, eGun6.transform.rotation);
        //bullet.velocity = transform.TransformDirection(Vector3.up * 5);
        bullet = Instantiate(bulletProjectile, eGun7.transform.position, eGun7.transform.rotation);
        //bullet.velocity = transform.TransformDirection(Vector3.up * 5);
        bullet = Instantiate(bulletProjectile, eGun8.transform.position, eGun8.transform.rotation);
        //bullet.velocity = transform.TransformDirection(Vector3.up * 5);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }
}
