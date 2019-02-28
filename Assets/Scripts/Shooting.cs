using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // shooting variables //
    public Transform gunLocation;
    public Rigidbody2D bulletProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D bullet;
            bullet = Instantiate(bulletProjectile, transform.position, transform.rotation);
            // Give the cloned object an initial velocity along the current
            // object's Y axis
            bullet.velocity = transform.TransformDirection(Vector3.up * 10);
        }
    }
}
