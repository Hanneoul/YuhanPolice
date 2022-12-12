using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{

    private void Update()
    {
        GameManager._instance.isSymbol = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager._instance.isSymbol = false;
        PlayerPrefs.SetInt("symbol" + MainManager._Maininstance.StageNum, 1);
        AudioManager._Audioinstance.sfxchange(3);
        GameManager._instance.StageClear();
    }
}
