using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    [Header("플레이어 정보")]
    public float jumpSpeed;

    bool jump;
    bool jump_Able = true;

    public GameObject[] healthPoint = new GameObject[2];
    int hp = 3;
        
    void Update()
    {
        JumpCheck();
        HP_Checker();
    }

    // 점프 버튼 함수
    public void Jump()
    {
        if (jump == false && jump_Able == true)
        {
            jump = true;
            jump_Able = false;
        }
    }

    // 점프 기능 함수
    void JumpCheck()
    {
        if (this.gameObject.transform.position.y >= 0f)
        {
            jump = false;
            jump_Able = true;
        }
        
        if (jump && jump_Able == false)
        {
            transform.Translate(Vector2.up * Time.deltaTime * jumpSpeed);
        }
        else if (jump == false && this.gameObject.transform.position.y >= -3f)
        {
            transform.Translate(Vector2.down * Time.deltaTime * jumpSpeed);
            jump_Able = false;
            
        }else if (this.gameObject.transform.position.y <= -3f)
        {
            jump_Able = true;
        }
    }
    //체력 감소에 따른 체력 아이콘 비활성화
    void HP_Checker()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
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
