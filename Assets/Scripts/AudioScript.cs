using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [HideInInspector]
    public AudioSource Music; // declears the audioSource
    public AudioClip death;

    //self explainitory variables
    public AudioSource Vocals;
    public AudioSource NoVocals;

    Character player;
    // Start is called before the first frame update
    void Start()
    {
        Music = this.gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        Vocals.volume = 2f;
        NoVocals.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.PlayerHasDied)
        {
            //PlayOneShot allows multiple sounds to be played
            // looking back i dont know why i did this since the player would only die once at a time
            // but im kinda scared to change it
            if(!Music.isPlaying && player.lives > 0) Music.PlayOneShot(death);

            //lowers (and raises) the volume using deltaTime
            Vocals.volume -= Time.deltaTime;
            NoVocals.volume += Time.deltaTime;
        }
        if (!player.PlayerHasDied)
        {
            Vocals.volume += Time.deltaTime;
            NoVocals.volume -= Time.deltaTime;

        }
    }
}
