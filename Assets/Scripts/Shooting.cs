using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // shooting variables //
    public Transform gunLocation;
    public Rigidbody2D bulletProjectile;
    private float shootDelay_default = 10f; // use this as the delay counter, dont change any other value in relation to shootdelay
    private float shootDelay;

    float timer = 5f;

    Character character;

    // Start is called before the first frame update
    void Start()
    {
        //shootDelay_default = character.shootDelay_sync;
        // sets the shootDelay, using two floats for convience
        shootDelay = shootDelay_default;
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    { 
        // as of right now (03.08.2019(MM/DD/YYY)) this is hardcoded to space, but thats subject to change
        // but if space is held down, shoots the bullet
        // downfall is that tapping space doesnt work as expected
        // but thats on the 'to fix' list
        if (Input.GetKey(KeyCode.Space) && !character.PlayerHasDied)
        {
            shootDelay--;
            if(shootDelay < 0)
            {
                ShootBullet();
                // plays the audio file, technically this is called twice because there's two gameobjects which have this script
                // but you wouldnt notice so its fine
                character.audioSrc.Play();
                shootDelay = shootDelay_default;
            }
        }
        if (character.PoweredUp)
        {
            shootDelay_default = 4;
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 5f;
                character.PoweredUp = false;
            }
        }
        if(!character.PoweredUp)
        {
            shootDelay_default = 10f;
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
