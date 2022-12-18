using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public float speed = 5f;

    public float posValue;
    public bool isStop;

    Vector3 startPos;
    public float newPos;

    public float times;


    void Start()
    {
        startPos = transform.position;
        startPos.z = 15;
    }
    void Update()
    {
        if(GameManager._instance != null)
        {
            if (!GameManager._instance.isDead && isStop == false)
            {
                times = Time.time;
                newPos = Mathf.Repeat(Time.deltaTime * speed, posValue);
                transform.position = startPos + Vector3.left * newPos;
            }
        }
        else if(isStop == false)
        {
            times = Time.time;
            newPos = Mathf.Repeat(Time.deltaTime  * speed, posValue);
            transform.position = startPos + Vector3.left * newPos;
        }
    }
}
