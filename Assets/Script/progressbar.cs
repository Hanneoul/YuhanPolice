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
        if(!GameManager._instance.isEenmy && !GameManager._instance.isOpening) {
            value += (Time.deltaTime);
            pbValue.fillAmount = value / 100;
            GameManager._instance.gameprogress = pbValue.fillAmount * 100;
        }
        
        if(pbValue.fillAmount == 1) {
            // 스테이지 클리어
        }
    }
}
