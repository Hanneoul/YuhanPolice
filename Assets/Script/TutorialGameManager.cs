using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGameManager : MonoBehaviour
{
    public GameObject[] credits;

    public bool isEenmy;
    public bool isTouch;
    public bool isDetected;
    public bool isSymbol;
    public bool isTimeout;
    public bool isOpening;
    public GameObject opeingobj;
    public GameObject typeObj;
    // Start is called before the first frame update
    void Start()
    {
        isOpening = true;
        opeingobj.SetActive(true);
        typeObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyTouchTimeOver() {
        
        // Enemy Over
        StartCoroutine(creditsOn(credits[1]));
        AudioManager._Audioinstance.sfxchange(2);
    }

    public void EnemyTouch() {
        // Enemy Clear
        StartCoroutine(creditsOn(credits[0]));
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
}
