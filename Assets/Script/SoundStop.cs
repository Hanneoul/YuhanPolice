using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundStop : MonoBehaviour, IPointerClickHandler
{

    public GameObject setting;
    public void OnPointerClick(PointerEventData eventData)
    {
        setting.SetActive(true);
        
        AudioManager._Audioinstance.BGMaudioSource.volume = 0.5f;
        GameManager._instance.isOpening = true;
        Time.timeScale = 0;
    }
}
