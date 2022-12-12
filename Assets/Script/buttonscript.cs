using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonscript : MonoBehaviour, IPointerClickHandler
{
    public GameObject obj;
    public void OnPointerClick(PointerEventData eventData)
    {
        obj.SetActive(true);
    }
}

