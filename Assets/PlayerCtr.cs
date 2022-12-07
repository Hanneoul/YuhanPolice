using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    [Header("�÷��̾� ���� ���ǵ�")]
    public float jumpSpeed;

    bool jump;
    bool jump_Able = true;
        
    void Update()
    {
        JumpCheck();
    }

    // ���� ��ư �Լ�
    public void Jump()
    {
        if (jump == false && jump_Able == true)
        {
            jump = true;
            jump_Able = false;
        }
    }

    // ���� ��� �Լ�
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

}
