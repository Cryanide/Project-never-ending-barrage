using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int lives;
    public Text lifeCounter;
    public Text ScoreDisplay;
    [HideInInspector]
    public bool PoweredUp;

    public float shootDelay_sync = 10f;

    EnemySpawn EnemySpawn;

    Enemy_Universal RulesOfEngagement;

    [HideInInspector]
    public bool PlayerHasDied = false;

    float respawnTime = 2f;

    [HideInInspector]
    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // as of right now (03.08.2019(MM/DD/YYY)) its hardcoded to 3, but that'll most likely be altered
        lives = 3;

        // we need to get this script as we need to keep track of the score
        EnemySpawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<EnemySpawn>();
        // i.e sets the text to 0
        ScoreDisplay.text = "Score: " + EnemySpawn.BadGuysDead.ToString();

        audioSrc = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // forces the players to be pronounced dead when they have no lives
        if (lives < 0) PlayerHasDied = true;

        // gets the current lives value and converts it to a string so you can read
        lifeCounter.text = lives.ToString();

        // same thing as the lives but for the score
        ScoreDisplay.text = "Score: " + EnemySpawn.BadGuysDead.ToString();

        // i actuallt dont know why we deactivate the player while we dont destroy it
        // but at least we can do resurrection abilites now if we wanted
        if(lives <= 0) gameObject.SetActive(false);

        // if the object cannot find the a script, keep looking
        if (RulesOfEngagement == null)
            // if this script cannot find a reference script, keep looking
            RulesOfEngagement = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy_Universal>();

        if(PlayerHasDied)
        {
            respawnTime -= Time.deltaTime;
            
            //removes powereUp state if dead
            PoweredUp = false;
            if(respawnTime <= 0)
            {
                // gets the sprite and collider components and sets them to true
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

                // the play is alive!
                PlayerHasDied = false;
                // resets the timer
                respawnTime = 2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            PlayerHasDied = true; //tells the world the player has died
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false; //disables the box collider so incase there's any stray bullets you wont lose a life
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false; //disables the sprite
            lives -= 1; // takes away a life if hit
        }
    }
}
