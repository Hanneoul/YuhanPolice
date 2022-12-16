using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class tutorialType : MonoBehaviour
{
    public TextMeshProUGUI openingText;
    public ScriptMnager scriptMnager;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Typing(openingText, scriptMnager.TutorialScript[0].Strings, 0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(TextMeshProUGUI typingText, string[] messages, float speed) 
    { 
        foreach(string message in messages) {
            for (int i = 0; i < message.Length; i++) 
            { 
                typingText.text = message.Substring(0, i + 1); 
                yield return new WaitForSeconds(speed);
            }
            yield return new WaitForSeconds(1F);
        }
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Tutorial", 1);
        SceneManager.LoadScene("MainScene");
    }
}
