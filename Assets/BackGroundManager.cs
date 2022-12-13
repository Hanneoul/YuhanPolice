using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    float speed = 5f;

    public float posValue;

    Vector2 startPos;
    float newPos;


    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;
    }
}
