using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    [Header("Player JumpSpedd")]
    public float jumpSpeed;
    Animator animator;
    Rigidbody2D rigidbody;
    bool jump;
    bool jump_Able = true;
    public GameObject[] healthPoint = new GameObject[3];
    public Sprite hpImage;

    public GameObject gameOverObj;
    public int hp;
    public BackGroundQuad backGroundManager;
    void Start()
    {
        backGroundManager = GameObject.Find("BackGroundQuad").GetComponent<BackGroundQuad>();
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        JumpCheck();
        HP_Checker();
    }

    public void Action()
    {
        animator.SetTrigger("action");
        AudioManager._Audioinstance.sfxchange(0);
    }

    Vector2 jumpVector = new Vector2(0f, 15f);
    // Player Jump
    public void Jump()
    {        
        if (jump == false && jump_Able == true && !GameManager._instance.isDetected)
        {
            jump = true;
            jump_Able = false;
            animator.SetTrigger("jump");
            AudioManager._Audioinstance.sfxchange(4);
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
            StartCoroutine(Dead());
        }
        if (hp <= 2)
        {
            healthPoint[hp].GetComponent<SpriteRenderer>().sprite = hpImage;
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("block"))
        {
            animator.SetTrigger("hurt_b");
            GameManager._instance.isOpening = true;
            backGroundManager.speed = 0;
            hp--;
        }
        else if (collision.CompareTag("UpObj"))
        {
            animator.SetTrigger("hurt_u");
            GameManager._instance.isOpening = true;
            backGroundManager.speed = 0;
            hp--;
        }        
    }
    IEnumerator Dead()
    {
        animator.SetTrigger("dead");
        GameManager._instance.isDead = true;
        rigidbody.velocity = new Vector2(0, 7f);
        yield return new WaitForSeconds(0.5f);
        rigidbody.velocity = new Vector2(0, -10f);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        gameOverObj.SetActive(true);

        Destroy(gameObject);
    }

    public void isOpeningfalse() {
        GameManager._instance.isOpening = false;
        backGroundManager.speed = 0.15f;
    }
}
