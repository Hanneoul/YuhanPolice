using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyTouch : MonoBehaviour, IPointerClickHandler
{
    public Image frontImage;
    float value;
    
    public bool isTouch;
    public bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        frontImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        value += (Time.deltaTime);
        frontImage.fillAmount = value / 5;
        if(frontImage.fillAmount == 1) {
            GameManager._instance.EnemyTouchTimeOver();
            GameManager._instance.isTimeout = true;
            Destroy(this.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Touch");
        GameManager._instance.isTouch = true;
        GameManager._instance.isEenmy = false;
        Destroy(this.gameObject.transform.parent.GetComponent<Transform>().gameObject);
        isTouch = true;
        GameManager._instance.EnemyTouch();
        // todo 원래 자리로 돌아가는 로직
    }


}
