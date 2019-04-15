using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{

    float scrollSpeed = -5f;
    Vector2 startPos;
    public float length;

    void Start()
    {
        // sets the startPos value as itself
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // the new pos gets altered everyframe, which loops every [length] seconds
        // if we use delta time the background wont move, Time.time is fine
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, length);

        // alters transfrom pos now
        transform.position = startPos + Vector2.up * newPos;
    }
}
