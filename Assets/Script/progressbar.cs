using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar : MonoBehaviour
{
    public Image pbValue;

    float value;
    // Start is called before the first frame update
    void Start()
    {
        pbValue.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        value += (Time.deltaTime);

        pbValue.fillAmount = value / 100;
    }
}
