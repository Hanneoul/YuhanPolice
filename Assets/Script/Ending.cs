using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public TextMeshProUGUI openingText;
    public ScriptMnager scriptMnager;
    public Image endingImage;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        int ram = Random.Range(0,3);
        endingImage.sprite = scriptMnager.endingImages[ram];
        StartCoroutine(Typing(openingText,scriptMnager.endingScript[ram].Strings, 0.1f));
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
        GameManager._instance.isOpening = false;
        // this.gameObject.SetActive(false);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartScene");
    }
}
