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
    public int BadGuysDead; // score counter
    public int SpecialCounter; // counter used to spawn special enemies

    // int to allow changing the amount of badguys on screen for difficulity reasons
    public int MaxBadGuysOnScreen = 4;

    /*change this to an array when we actually do work*/
    /* EDIT: its now an array*/
    public GameObject[] BadGuys;
    GameObject[] SpawnLocations;
    GameObject[] SpecialSpawnLocations;
    public GameObject[] SpecialEnemies;

    // i have no idea what a list is, but people said its better to use (in this context) so i used it
    public List<GameObject> BadGuysOnScreen;
    

    // offsets the spawning slightly to prevent enemies from spawning in the same location everytime
    Vector3 BadGuyOffset; 

    // something to prevent the spawning of new enemies if screen is full
    bool NoSpawn = false;

    // simple bool to check if an special enemy can spawn, defaulted to false
    bool SpawnSpecial;

    //to check if theres already a special enemy
    GameObject specialEnemy;
    

    // Start is called before the first frame update
    void Start()
    {
        // these just automate the process of finding the spawn locations, they dont change at all
        // but at least we can add and remove as we please
        SpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLoc");
        SpecialSpawnLocations = GameObject.FindGameObjectsWithTag("SpecialSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        ClearList();
        // sets a new vector every frame
        BadGuyOffset = new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0); 

        // tries and finds a special enemy every frame
        // there's for sure a better way to do this, but it uses such little CPU power that it doesnt matter
        // then again I have 6 cores... but its 2019, if you have less than 2 then you have a toaster
        specialEnemy = GameObject.FindGameObjectWithTag("SpecialEnemy");

        // if the code finally finds a special enemy, set its counter to zero 
        //and stay at zero till the special enemy is removed
        if (specialEnemy != null) SpecialCounter = 0;

        // if the counter is less than zero
        // and spawn special is false (meaning you CANT spawn a special)
        // and there isnt already a special enemy
        // spawn one
        // then tell the code that it cannot spawn another immedietly after
        if (SpecialCounter >= 100 && !SpawnSpecial && specialEnemy == null) SpawnSpecial = true;
        else SpawnSpecial = false;

        // since we want no more than 4 enemies on screen, this code checks for that
        // if theres less then it spawns in enemies until there would be more than 4
        // and the moment one is destroyed another one fills the spot
        if (!NoSpawn && BadGuysOnScreen.Count < MaxBadGuysOnScreen)
        {
            ReleaseTheHounds();
            if (BadGuysOnScreen.Count > MaxBadGuysOnScreen) NoSpawn = true;
        }
    }

    void ReleaseTheHounds()
    {
        // spawns in an enemy and at the same time adds him to the list
          BadGuysOnScreen.Add(
              Instantiate(BadGuys[Random.Range(0, BadGuys.Length)], // the prefab we spawning in
              SpawnLocations[Random.Range(0, SpawnLocations.Length)].transform.position + BadGuyOffset, 
              SpawnLocations[Random.Range(0, SpawnLocations.Length)].transform.rotation
              ));

        // if the code says it can spawn in a special enemy, do it
        if(SpawnSpecial)
        {
            Instantiate(SpecialEnemies[Random.Range(0, SpecialEnemies.Length)],
                SpecialSpawnLocations[Random.Range(0, SpecialSpawnLocations.Length)].transform);

        }
    }

    // if any of the enemies is destroyed, it removes it from the list, so another one can be spawned in
    void ClearList()
    {
        for (int i = 0; i < BadGuysOnScreen.Count; i++)
        {
            if (BadGuysOnScreen[i] == null) BadGuysOnScreen.RemoveAt(i);
        }
    }
}
