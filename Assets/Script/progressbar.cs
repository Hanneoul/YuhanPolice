using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar : MonoBehaviour
{
    public Image pbValue;

    public GameManager gameManager;

    float value;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pbValue.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        value += (Time.deltaTime);

        pbValue.fillAmount = value / 100;

        if(pbValue.fillAmount == 1) {
            // 스테이지 클리어
        }
    }
}
