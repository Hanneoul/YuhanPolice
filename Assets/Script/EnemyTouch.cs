using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyTouch : MonoBehaviour, IPointerClickHandler
{
    public Image frontImage;
    public GameManager gameManager;
    float value;
    
    public bool isTouch;
    public bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        frontImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        value += (Time.deltaTime);
        frontImage.fillAmount = value / 5;
        if(frontImage.fillAmount == 1) {
            gameManager.EnemyTouchTimeOver();
            Destroy(this.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Touch");
        gameManager.isTouch = true;
        gameManager.isEenmy = false;
        Destroy(this.gameObject);
        isTouch = true;
        gameManager.EnemyTouch();
        // todo 원래 자리로 돌아가는 로직
    }


}
