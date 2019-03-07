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
    public GameObject[] SpawnLocations;
    public List<GameObject> BadGuysOnScreen;

    Vector3 BadGuyOffset;

    bool NoSpawn = false;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLoc");
    }

    // Update is called once per frame
    void Update()
    {
        ClearList();
        BadGuyOffset = new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0);

        if (!NoSpawn && BadGuysOnScreen.Count < 4)
        {
            ReleaseTheHounds();
            if (BadGuysOnScreen.Count > 4) NoSpawn = true;
        }
        if (NoSpawn && BadGuysOnScreen.Count == 0)
        {
            NoSpawn = false;
        }
    }

    void ReleaseTheHounds()
    {
          BadGuysOnScreen.Add(
              Instantiate(BadGuys, // the prefab we spawning in
              SpawnLocations[Random.Range(0, SpawnLocations.Length)].transform.position + BadGuyOffset, 
              SpawnLocations[Random.Range(0, SpawnLocations.Length)].transform.rotation
              ));
    }

    void ClearList()
    {
        for (int i = 0; i < BadGuysOnScreen.Count; i++)
        {
            if (BadGuysOnScreen[i] == null)
            {
                BadGuysOnScreen.RemoveAt(i);
            }
        }
    }
}
