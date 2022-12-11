using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    [Header("Player JumpSpedd")]
    public float jumpSpeed;

    Rigidbody2D rigidbody;
    bool jump;
    bool jump_Able = true;
    public GameObject[] healthPoint = new GameObject[3];
    public int hp = 3;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        JumpCheck();
        HP_Checker();
        DetectEnemy();
    }

    void DetectEnemy()
    {
    }

    Vector2 jumpVector = new Vector2(0f, 15f);
    // Player Jump
    public void Jump()
    {        
        if (jump == false && jump_Able == true && !GameManager._instance.isDetected)
        {
            jump = true;
            jump_Able = false;
        }
    }

    // Jump Check
    void JumpCheck()
    {
        if (this.gameObject.transform.position.y >= 0f)
        {
            jump = false;
            jump_Able = true;
        }
        
        if (jump && jump_Able == false)
        {
            rigidbody.velocity = jumpVector;            
        }
        else if (jump == false && this.gameObject.transform.position.y >= 3f)
        {
            rigidbody.velocity = -jumpVector;
            jump_Able = false;
            
        }else if (this.gameObject.transform.position.y <= -3f)
        {
            rigidbody.velocity = Vector2.zero;
            jump_Able = true;
        }
    }

    void HP_Checker()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        if (hp <= 2)
        {
            healthPoint[hp].SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("block") || collision.CompareTag("UpObj"))
        {
            hp--;
        }
    }

}
