using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public bool isOpening;
    // 범인 등장
    public bool isEenmy;
    public bool isTouch;
    float times;

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

    public void EnemyTouchTimeOver() {
        // Enemy Over
        StartCoroutine(creditsOn(credits[4]));
    }

    public void EnemyTouch() {
        // Enemy Clear
        StartCoroutine(creditsOn(credits[3]));
    }

    IEnumerator creditsOn(GameObject scnces) {
        scnces.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        scnces.SetActive(false);
        isEenmy = false;
        isTouch = false;
        yield return 0;
    }

}
