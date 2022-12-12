using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BGMController : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] bgmSprite;
    public bool isTouch = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(isTouch) {
            isTouch = false;
            this.gameObject.GetComponent<Image>().sprite = bgmSprite[0];
            AudioManager._Audioinstance.BGMaudioSource.volume = 0;
        }
        else {
            isTouch = true;
            this.gameObject.GetComponent<Image>().sprite = bgmSprite[1];
            AudioManager._Audioinstance.BGMaudioSource.volume = 1f;
        }
    }
}
