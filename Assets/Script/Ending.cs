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

    void Start()
    {
        StartCoroutine(Typing(openingText, 0.1f));
    }

    IEnumerator Typing(TextMeshProUGUI typingText,float speed) 
    { 
        for(int i=0; i< 4; i++) {
            string[] messages = scriptMnager.endingScript[i].Strings;
            endingImage.sprite = scriptMnager.endingImages[i];
            foreach(string message in messages) {
                for (int x = 0; x < message.Length; x++) 
                { 
                    typingText.text = message.Substring(0, x + 1); 
                    yield return new WaitForSeconds(speed);
                }
                yield return new WaitForSeconds(1F);
            }
        }
        
        yield return new WaitForSeconds(1f);
        GameManager._instance.isOpening = false;
        // this.gameObject.SetActive(false);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartScene");
    }
}
