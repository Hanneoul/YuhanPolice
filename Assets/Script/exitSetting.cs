using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class exitSetting : MonoBehaviour, IPointerClickHandler
{
    public GameObject asset;
    public GameObject credit;


    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
        AudioManager._Audioinstance.BGMaudioSource.volume = 1f;
        GameManager._instance.isOpening = false;
        credit.SetActive(false);
        asset.SetActive(false);
        Time.timeScale = 1;
    }
}
