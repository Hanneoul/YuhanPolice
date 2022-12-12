using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(-3f * Time.deltaTime ,0f));
    }
}
