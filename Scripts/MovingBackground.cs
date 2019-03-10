using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    // Start is called before the first frame update

    float scrollSpeed = -5f;
    Vector2 startPos;
    public float length;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, length);
        transform.position = startPos + Vector2.up * newPos;
    }
}
