using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AssetController : MonoBehaviour, IPointerClickHandler
{
    public GameObject AssetObj;
    public void OnPointerClick(PointerEventData eventData)
    {
        AssetObj.SetActive(true);
    }
}
