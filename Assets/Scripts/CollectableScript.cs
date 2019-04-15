using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    /*
     * 
     * this script merely deals with the collecting of the collectible
     * if collected gives the player a powered up state
     * the spawning of these is done in 
     * Enemy_Universal.cs
     * 
     */

    Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        //destroys this within ten seconds
        Destroy(this.gameObject, 10f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            character.PoweredUp = true;
            Destroy(this.gameObject);
        }
    }
}
