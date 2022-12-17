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

    public float time;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        // frontImage.fillAmount = 0;
        startPos = frontImage.rectTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        // value += (Time.deltaTime);
        // frontImage.fillAmount = value / 5;
        // if(frontImage.fillAmount == 1) {
        //     GameManager._instance.EnemyTouchTimeOver();
        //     GameManager._instance.isTimeout = true;
        //     GameManager._instance.isTouchFailed = true;
        //     Destroy(this.gameObject);
        // }

        frontImage.rectTransform.localScale = startPos * ((time / 2) - 1 );
        time += Time.deltaTime;
        if (frontImage.rectTransform.localScale.x >= 0.1f)
        {
            time = 0;
            GameManager._instance.EnemyTouchTimeOver();
            GameManager._instance.isTimeout = true;
            GameManager._instance.isTouchFailed = true;
            Destroy(this.gameObject);
            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(time >= 0.8f && time < 1.2f){
            Debug.Log("Touch");
            GameManager._instance.isTouch = true;
            GameManager._instance.isEenmy = false;
            Destroy(this.gameObject);
            isTouch = true;
            GameManager._instance.EnemyTouch();
            // todo 원래 자리로 돌아가는 로직
        }
        else {
            time = 0;
            GameManager._instance.EnemyTouchTimeOver();
            GameManager._instance.isTimeout = true;
            GameManager._instance.isTouchFailed = true;
            Destroy(this.gameObject);
        }
        
    }


}
