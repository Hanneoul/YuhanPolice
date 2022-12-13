using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorailTouch : MonoBehaviour, IPointerClickHandler
{
    public Image frontImage;
    public TutorialGameManager gameManager;
    float value;
    
    public bool isTouch;
    public bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        frontImage.fillAmount = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<TutorialGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        value += (Time.deltaTime);
        frontImage.fillAmount = value / 5;
        if(frontImage.fillAmount == 1) {
            gameManager.EnemyTouchTimeOver();
            gameManager.isTimeout = true;
            Destroy(this.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Touch");
        Time.timeScale = 1;
        gameManager.isTouch = true;
        gameManager.isEenmy = false;
        Destroy(this.gameObject);
        isTouch = true;
        gameManager.EnemyTouch();
        // todo 원래 자리로 돌아가는 로직
    }
}
