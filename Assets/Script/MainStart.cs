using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MainStart : MonoBehaviour, IPointerClickHandler
{
    public bool firstPlay;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Touch");
        if(PlayerPrefs.GetInt("Tutorial") == 0) {
            SceneManager.LoadScene("Tutorial");
        }
        else {
            SceneManager.LoadScene("MainScene");
        }
        

    }
}
