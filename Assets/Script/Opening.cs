using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI openingText;
    public ScriptMnager scriptMnager;
    public Image openingImage;
    public TutorialGameManager gameManager;
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<TutorialGameManager>();
        StartCoroutine(Typing(openingText, 0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(TextMeshProUGUI typingText, float speed) 
    { 
        for(int x = 0; x < 4; x++) {
            string[] messages =  scriptMnager.openingScript[x].Strings;
            openingImage.sprite = scriptMnager.openingImages[x];
            foreach(string message in messages) {
                for (int i = 0; i < message.Length; i++) 
                { 
                    typingText.text = message.Substring(0, i + 1); 
                    yield return new WaitForSeconds(speed);
                }
            yield return new WaitForSeconds(1F);
            }
        }
        
        yield return new WaitForSeconds(1f);
        gameManager.isOpening = false;
        gameManager.typeObj.SetActive(true);
        this.gameObject.SetActive(false);
    } 
}
