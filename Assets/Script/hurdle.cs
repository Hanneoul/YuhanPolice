using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hurdle : MonoBehaviour
{
    [Header("��ü��")]
    public bool item;
    public bool Enemy;
    public bool up_Obj;
    public bool down_Obj;
    public bool isStop;

    public Sprite mainImage;

    
    [Header("����")]
    public int speed;
    
    public GameObject touch;


    
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = mainImage;
    }
        
    void Update()
    {
        if(!isStop) {
            this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(GameManager._instance.isTouch || GameManager._instance.isTimeout ) {
            Destroy(this.gameObject);
        }

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

        if(Enemy)
        {
            if(collision.CompareTag("Player"))
            {
                isStop = true;
                Debug.Log("test");
                GameObject temp = Instantiate(touch, GameObject.Find("Canvas").transform.localPosition 
                                    + new Vector3(Random.Range(-200,-150),0,0), 
                                        Quaternion.identity, 
                                        GameObject.Find("Canvas").transform);
                
            }
        }

        if(collision.CompareTag("Delete")) {
            Destroy(this.gameObject);
        }
    }
}
