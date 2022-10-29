using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector2 startPos;
    public Rigidbody2D rb;
    public int jumpCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            { 
                rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                jumpCount--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bottom")
        {
            jumpCount = 2;
        }

        if(collision.gameObject.tag == "Top")
        {
            jumpCount = 0;
        }
    }
}
