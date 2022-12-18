using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class nextStage : MonoBehaviour, IPointerClickHandler
{
    public GameObject endingObj;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(PlayerPrefs.GetInt("symbol1") == 1 && PlayerPrefs.GetInt("symbol2") == 1 && PlayerPrefs.GetInt("symbol3") == 1)
        {
            Time.timeScale = 1;
            endingObj.SetActive(true);
        }
        else {
            SceneManager.LoadScene("MainScene");
        }
        
        
    }
}