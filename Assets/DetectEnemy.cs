using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (GameManager._instance.isDetected)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0f));

        }
        else
        {
            //transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));

        }
    }
}
