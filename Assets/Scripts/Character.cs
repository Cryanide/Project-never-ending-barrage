using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int lives;
    public Text lifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounter.text = lives.ToString();
        if(lives < 0)
        {
            lives = 0;
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
