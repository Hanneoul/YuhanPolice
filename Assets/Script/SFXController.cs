using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SFXController : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] bgmSprite;
    public bool isTouch = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(isTouch) {
            isTouch = false;
            this.gameObject.GetComponent<Image>().sprite = bgmSprite[0];
            AudioManager._Audioinstance.SFXaudioSource.volume = 0;
        }
        else {
            isTouch = true;
            this.gameObject.GetComponent<Image>().sprite = bgmSprite[1];
            AudioManager._Audioinstance.SFXaudioSource.volume = 1f;
        }
    }
}