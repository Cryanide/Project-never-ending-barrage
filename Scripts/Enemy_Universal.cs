using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Universal : MonoBehaviour
{

    EnemySpawn KillCounter;

    public int ScoreGained;
    public int health;

    [HideInInspector]
    public bool InsidePlayArea;
    public GameObject[] EntryPoints;

    public bool SpecialEnemy; // not used for now



    // Start is called before the first frame update

    void Awake()
    {
        // i still cannot believe I had to use the Awake method, never though i'd need to
        // since Awake() is called before start(), and in another scripts I have them refering to this value
        // i need to be sure that EntryPoints isnt null
        EntryPoints = GameObject.FindGameObjectsWithTag("EntryPoint");
    }

    void Start()
    {
        KillCounter = GameObject.FindGameObjectWithTag("Spawn").GetComponent<EnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {

        // locks the Y axis, so the sprites cant somehow become 1-D
        // only happens during the warp phase, but it comes with the benift that the gameObject
        // CANNOT move like a 3d object, this script will NOT allow it
        // ..hopefully
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);

        // self explaitory
        if (health <= 0) Destroy(this.gameObject);
           
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if the player hits an enemy add to the score, as well as the special counter
        // specialCounter uses ScoreGained as well
        // so the better you do the faster special enemies come
        // basically a really basic variable difficulity
        if (col.tag == "PlayerBullets")
        {
            KillCounter.BadGuysDead += ScoreGained;
            KillCounter.SpecialCounter += ScoreGained;
            health--;
            Destroy(col.gameObject);

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        // used to detect if the ships are inside the visible area
        if(col.gameObject.tag == "PlayArea")
        {
            InsidePlayArea = true;
        }
    }
}
