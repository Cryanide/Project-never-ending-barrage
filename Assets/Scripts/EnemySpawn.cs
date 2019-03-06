using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    /*
     * this script will control the spawning of enemies
     * and keep track how much enemies are killed
     * so bosses can spawn
     * 
     */
    public int BadGuysDead;

    /*change this to an array when we actually do work*/
    public GameObject BadGuys;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReleaseTheHounds()
    {
        Instantiate(BadGuys);
    }
}
