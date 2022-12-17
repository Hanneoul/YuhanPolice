using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public int StageNum;
    public ScriptMnager scriptMnager;
    public bool isOpening;
    // 범인 등장
    public bool isEenmy;
    public bool isTouch;
    public bool isTouchFailed;
    public bool isDetected;
    public bool isTimeout;
    public bool isGameEnd;
    public bool isSymbol;
    public bool isSetting;
    public bool punching;
    public bool isDead;

    float times;

    [Header("Stage Clear Object")]
    public GameObject stageClear;
    public float gameprogress;
    public TextMeshProUGUI stageClearProgressText;
    public Image endingImage;

    [Header("GameEnding")]
    public GameObject endingobj;
    public GameObject[] credits;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        isOpening = true;
        // todo 테스트 할때 아래 한줄 주석처리 ㄱ
        StageNum = MainManager._Maininstance.StageNum;
        isOpening = false;
    }

    public void EnemyTouchTimeOver() {
        
        // Enemy Over
        StartCoroutine(creditsOn(credits[4]));
        AudioManager._Audioinstance.sfxchange(2);
    }

    public void EnemyTouch() {
        // Enemy Clear
        StartCoroutine(creditsOn(credits[3]));
        AudioManager._Audioinstance.sfxchange(3);
    }

    IEnumerator creditsOn(GameObject scnces) {
        if(scnces != null)
        {
        scnces.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        scnces.SetActive(false);
        isEenmy = false;
        isTouch = false;
        isTimeout = false;
        yield return 0;
        }

    }

    public void StageClear() {
        if (stageClear != null)
        {
            isGameEnd = true;
            // stageClearProgressText.text = int.Parse(gameprogress.ToString()).ToString() + " %";
            endingImage.sprite = scriptMnager.stageClearImages[StageNum - 1];
            stageClear.SetActive(true);
            // todo 심볼이 3개라면 Ending 오브젝트 활성화 다음으로 클릭 시
            // if (PlayerPrefs.GetInt("symbol1") == 1 && PlayerPrefs.GetInt("symbol2") == 1 && PlayerPrefs.GetInt("symbol3") == 1)
            // {
            AudioManager._Audioinstance.bgmchange(0);
                // endingobj.SetActive(true);
            // }
        }
    }
}
