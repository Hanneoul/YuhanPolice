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
        MainManager._Maininstance.symbolSaveData[GameManager._instance.StageNum -1] = 1;
        AudioManager._Audioinstance.sfxchange(3);
        GameManager._instance.StageClear();
    }
}
