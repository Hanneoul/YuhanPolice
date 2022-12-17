using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    float speed = 5f;

    public float posValue;

    Vector3 startPos;
    float newPos;


    void Start()
    {
        startPos = transform.position;
        startPos.z = 15;
    }
    void Update()
    {
        if(GameManager._instance != null)
        {
            if (!GameManager._instance.isDead)
            {
                newPos = Mathf.Repeat(Time.time * speed, posValue);
               transform.position = startPos + Vector3.left * newPos;
            }
        }
        else
        {
            newPos = Mathf.Repeat(Time.time * speed, posValue);
            transform.position = startPos + Vector3.left * newPos;
        }
    }
}
