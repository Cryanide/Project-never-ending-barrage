using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public bool EnemyBullet;
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3.0f);
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
            Debug.Log("Camera");
        }

        if (EnemyBullet)
        {
            if (col.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
                character.lives -= 1;
                Debug.Log("PlayerHit");
            }
        }
        else if(!EnemyBullet)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject);
                Debug.Log("EnemyHit");
            }
        }
    }
}
