using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aa : MonoBehaviour
{
    float time;
    bool first;
    bool second;
    bool third;
    bool fourth;
    

    private void Update()
    {
        time += Time.deltaTime;

        if (time > 24f && first == false)
        {
            Time.timeScale = 0;
            first = true;
            time = 0;
        }
        
        if (time > 10f && first == true && second == false)
        {
            Time.timeScale = 0;
            second = true;
            time = 0;
        }

        if (time > 9f && second == true && third == false)
        {
            Time.timeScale = 0;
            third = true;
            time = 0;
        }

        if (time > 17f && third == true && fourth == false)
        {
            Time.timeScale = 0;
            fourth = true;
            time = 0;

        }

        if (time > 19f && fourth == true)
        {
            Time.timeScale = 0;
            time = 0;
        }
        
    }

    public void TimeScale()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }


}
