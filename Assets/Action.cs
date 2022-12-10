using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    bool action;

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
        yield return new WaitForSeconds(1f);
        action = false;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("UpObj"))
        {            
            if (action)
            {
                Debug.Log("여기?");
                collision.gameObject.SetActive(false);
                action = false;
                Debug.Log("여기!");
            }
        }
    }
}
