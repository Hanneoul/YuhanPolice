using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI openingText;
    public ScriptMnager scriptMnager;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        int ram = Random.Range(0,4);
        StartCoroutine(Typing(openingText,scriptMnager.openingScript[ram].Strings, 0.2f));
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
        }
        yield return new WaitForSeconds(3f);
        GameManager._instance.isOpening = false;
        this.gameObject.SetActive(false);
    } 
}
