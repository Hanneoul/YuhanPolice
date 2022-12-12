using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public int[] symbolSaveData;
    public Sprite[] symbolsImage;
    public GameObject[] symbols;
    // Start is called before the first frame update
    void Start()
    {
        symbolSaveData[0] = PlayerPrefs.GetInt("symbol1");
        symbolSaveData[1] = PlayerPrefs.GetInt("symbol2");
        symbolSaveData[2] = PlayerPrefs.GetInt("symbol3");
        for(int i =0; i < symbolSaveData.Length; i++) {
            if(symbolSaveData[i] == 1) {
                symbols[i].gameObject.SetActive(true);
            }
            else {
                symbols[i].gameObject.SetActive(false);
            }
        }
    }
}
