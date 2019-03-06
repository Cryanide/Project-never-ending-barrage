using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Universal : MonoBehaviour
{

    EnemySpawn KillCounter;

    public int ScoreGained;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        KillCounter = GameObject.FindGameObjectWithTag("Spawn").GetComponent<EnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullets")
        {
            KillCounter.BadGuysDead += ScoreGained;
            health--;
            Destroy(col.gameObject);

        }
    }
}
