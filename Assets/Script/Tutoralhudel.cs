using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutoralhudel : MonoBehaviour
{
    [Header("Kind")]
    public bool item;
    public bool Enemy;
    public bool up_Obj;
    public bool down_Obj;
    public bool isStop;
    bool tutorial;
    public Sprite mainImage;

    public TutorialGameManager gameManager;

    static int count;
    
    [Header("Soeed")]
    public int speed;
    
    public GameObject touch;
    BoxCollider2D boxCollider;
    int rotate;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<TutorialGameManager>();
        boxCollider = GetComponent<BoxCollider2D>();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = mainImage;
        count++;
    }
        
    void Update()
    {
        if(!isStop && !gameManager.isOpening) {
            this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(gameManager.isTouch || gameManager.isTimeout ) {
            Destroy(this.gameObject);
        }
        if (Enemy)
        {
            if (transform.position.x < 2f)
            {
                isStop = true;
                gameManager.isDetected = true;
                gameObject.transform.position = new Vector2(2.1f, transform.position.y);  
            }
        }
        if (!tutorial && !item && count != 3)
        {
            if (gameObject.transform.position.x <= -4f)
            {
                Time.timeScale = 0;
                tutorial = true;
            }
        }

        if (TutorialGameManager.punching)
        {
            rotate += 2;
            this.transform.position = new Vector3(gameObject.transform.position.x, rotate*5*Time.deltaTime);
            this.transform.localRotation = Quaternion.Euler(0, 0, rotate * 5);
            boxCollider.enabled = false;
            if (transform.position.y > 10f)
            {
                TutorialGameManager.punching = false;
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
                gameManager.isDetected = false;

                //isStop = true;
                Debug.Log("test");
                GameObject temp = Instantiate(touch, GameObject.Find("Canvas").transform.localPosition 
                                    + new Vector3(Random.Range(-200,-150),0,0), 
                                        Quaternion.identity, 
                                        GameObject.Find("Canvas").transform);
                Time.timeScale = 0;
                
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
