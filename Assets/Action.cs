using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
     bool action;
    GameObject upObj;
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
        if (upObj != null)
        {
            Destroy(upObj);
        }
        yield return new WaitForSeconds(1f);
        action = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("UpObj"))
        {
            upObj = collision.gameObject;
            Debug.Log(upObj);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("UpObj"))
        {
            upObj = null;            
        }
    }
}
