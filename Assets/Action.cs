using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    bool action;
    GameObject upObj;
    hurdle hurdle;
    
    public void ActionBtn()
    {
        if (!action)
        {            
            StartCoroutine(ActionCoroutine());               
        }
    }
    private IEnumerator ActionCoroutine()
    {
        action = true;
        
        yield return new WaitForSeconds(0.5f);
        if (upObj != null)
        {
            TutorialGameManager.punching = true;
            Debug.Log(upObj);

        }
        if (hurdle != null)
        {
            hurdle.punching = true;
        }
        action = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("UpObj"))
        {
            upObj = collision.gameObject;
            hurdle = upObj.GetComponent<hurdle>();
            Debug.Log(upObj);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("UpObj"))
        {
            upObj = null;

            Debug.Log("Exit");
        }
    }
}
