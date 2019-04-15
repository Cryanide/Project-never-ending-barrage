using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Universal : MonoBehaviour
{
    /*
     * this script is essentily
     * the ground rules ALL enemies have to follow
     * even special ones
     * deals with scoring as well
     */

    EnemySpawn KillCounter;

    public int ScoreGained;
    public int health;

    [HideInInspector]
    public bool InsidePlayArea;
    public GameObject[] EntryPoints;

    public bool SpecialEnemy; // not used for now

    // deathsound prefab to spawn
    public GameObject deathSoundPrefab;

    //since we cant access the assest folder (effectently) in game, we gotta do it like this
    public GameObject collectable;  

    //int used for random number generation
    int collectableDrop;

    Character character;


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
        collectableDrop = Random.Range(0, 100);
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
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
        // plays audio src
        if (health <= 0)
        {
            // spawns the gameobject which does the deathSound
            Instantiate(deathSoundPrefab);
            if(collectableDrop >= 40)
            {
                // if theres no collectible and the player isnt already poweredUp, spawn on if applicable
                if(!GameObject.FindGameObjectWithTag("Collectable") && !character.PoweredUp) Instantiate(collectable, this.transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
           
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

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "MainCamera") Destroy(this.gameObject);
    }
}
