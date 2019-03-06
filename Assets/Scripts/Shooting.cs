using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // shooting variables //
    public Transform gunLocation;
    public Rigidbody2D bulletProjectile;
    float shootDelay_default = 10f; // use this as the delay counter, dont change any other value in relation to shootdelay
    float shootDelay;

    // Start is called before the first frame update
    void Start()
    {
        shootDelay = shootDelay_default;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shootDelay--;
            if(shootDelay < 0)
            {
                ShootBullet();
                shootDelay = shootDelay_default;
            }
        }

    }
    void ShootBullet()
    {
        Rigidbody2D bullet;
        bullet = Instantiate(bulletProjectile, transform.position, transform.rotation);
        // Give the cloned object an initial velocity along the current
        // object's Y axis
        bullet.velocity = transform.TransformDirection(Vector3.up * 25);
    }
}
