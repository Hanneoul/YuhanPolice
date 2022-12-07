using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdle : MonoBehaviour
{
    [Header("정체성")]
    public bool item;
    public bool up_Obj;
    public bool down_Obj;
    
    [Header("변수")]
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
