using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject[] BackGround;
    int i = 0;

    private void Update()
    {
        if (BackGround[i].transform.position.x <= -75f)
        {
            BackGround[i].transform.position = new Vector2(45f, 0f);

            i++;
        }
        if (i == 2)
        {
            i = 0;
        }
    }
}
