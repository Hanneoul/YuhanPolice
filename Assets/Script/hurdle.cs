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
    public bool punching;
    public Sprite mainImage;

    int rotate;
    BoxCollider2D boxCollider;

    [Header("Speed")]
    public int speed;
    
    public GameObject touch;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = mainImage;
        boxCollider = GetComponent<BoxCollider2D>();
    }
        
    void Update()
    {
        if(!isStop && !GameManager._instance.isOpening && !GameManager._instance.isDead) {
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

        if (punching)
        {
            rotate += 2;
            this.transform.position = new Vector3(gameObject.transform.position.x, rotate * 5 * Time.deltaTime);
            this.transform.localRotation = Quaternion.Euler(0, 0, rotate * 5);
            boxCollider.enabled = false;
            if (transform.position.y > 10f)
            {                
                Destroy(this.gameObject);
            }
        }
        else
        {
            rotate = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("deleteObject", 10f);
        }

        if (collision.CompareTag("Detect"))
        {

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
