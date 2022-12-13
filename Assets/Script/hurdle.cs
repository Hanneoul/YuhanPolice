using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hurdle : MonoBehaviour
{
    [Header("Kind")]
    public bool item;
    public bool Enemy;
    public bool up_Obj;
    public bool down_Obj;
    public bool isStop;
    
    public Sprite mainImage;

    
    [Header("Soeed")]
    public int speed;
    
    public GameObject touch;


    
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = mainImage;
    }
        
    void Update()
    {
        if(!isStop && !GameManager._instance.isOpening) {
            this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(GameManager._instance.isTouch || GameManager._instance.isTimeout ) {
            Destroy(this.gameObject);
        }
        if (Enemy)
        {
            if (transform.position.x < 2f)
            {
                isStop = true;
                GameManager._instance.isDetected = true;
                gameObject.transform.position = new Vector2(2.1f, transform.position.y);  
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("deleteObject", 10f);
        }

        if (item)
        {
            if(collision.CompareTag("Player"))
            {
                Destroy(this.gameObject.transform.parent.GetComponent<Transform>().gameObject);
            }
        }

        if(Enemy)
        {
            if(collision.CompareTag("Player"))
            {
                GameManager._instance.isDetected = false;

                //isStop = true;
                Debug.Log("test");
                GameObject temp = Instantiate(touch, GameObject.Find("Canvas").transform.localPosition 
                                    + new Vector3(Random.Range(-200,-150),0,0), 
                                        Quaternion.identity, 
                                        GameObject.Find("Canvas").transform);
                
            }
        }

        if(collision.CompareTag("Delete")) {
            Destroy(this.gameObject.transform.parent.GetComponent<Transform>().gameObject);
        }
    }

    public void deleteObject() {
        Destroy(this.gameObject.transform.parent.GetComponent<Transform>().gameObject);
    }
}
