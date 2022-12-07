using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdle : MonoBehaviour
{
    [Header("��ü��")]
    public bool item;
    
    [Header("����")]
    public int speed;
    
    
    void Start()
    {
        
    }
        
    void Update()
    {
        this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (item)
        {
            if(collision.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
