using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSoundScript : MonoBehaviour
{
    AudioSource asrc;

    // Start is called before the first frame update
    void Start()
    {
        asrc = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!asrc.isPlaying)
        {
            Destroy(this);
        }
    }
}
