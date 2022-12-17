using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDescrip : MonoBehaviour
{
    public float speed;
    public TutorialGameManager tutorialGameManager;

    void Start()
    {
        tutorialGameManager = GameObject.Find("GameManager").GetComponent<TutorialGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialGameManager.isDetected || tutorialGameManager.isSymbol)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0f));

        }
        else if(tutorialGameManager.isTouch)
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));
            if (gameObject.transform.position.x <= 1f)
            {
                tutorialGameManager.isTouch = false;
            }
        }
    }
}
