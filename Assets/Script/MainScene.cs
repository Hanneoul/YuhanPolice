using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public int[] symbolSaveData;
    public Image[] symbolsImage;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< 3; i++) {
            symbolsImage[i] = Resources.Load("game_symbol_stage" + (i+1) ) as Image;
        }

        symbolSaveData[0] = PlayerPrefs.GetInt("symbol1");
        symbolSaveData[1] = PlayerPrefs.GetInt("symbol2");
        symbolSaveData[2] = PlayerPrefs.GetInt("symbol3");
        for(int i =0; i < symbolSaveData.Length; i++) {
            if(symbolSaveData[i] == 1) {
                symbolsImage[i].gameObject.SetActive(true);
            }
            else {
                symbolsImage[i].gameObject.SetActive(false);
            }
        }
    }
}
