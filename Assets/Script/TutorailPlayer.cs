using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorailPlayer : MonoBehaviour
{
   [Header("Player JumpSpedd")]
    public TutorialGameManager gameManager;
    public float jumpSpeed;
    Animator animator;
    Rigidbody2D rigidbody;
    bool jump;
    bool jump_Able = true;
    public GameObject[] healthPoint = new GameObject[3];
    public int hp;
    public Sprite hpImage;
    public BackGroundManager backGroundManager;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<TutorialGameManager>();
    }
    void Update()
    {
        JumpCheck();
        HP_Checker();        
    }

    public void Action()
    {
        Time.timeScale = 1f;
        animator.SetTrigger("action");
        AudioManager._Audioinstance.sfxchange(0);
    }

    Vector2 jumpVector = new Vector2(0f, 15f);
    // Player Jump
    public void Jump()
    {        
        if (jump == false && jump_Able == true && !gameManager.isDetected)
        {
            Time.timeScale = 1f;
            jump = true;
            jump_Able = false;
            animator.SetTrigger("jump");
            AudioManager._Audioinstance.sfxchange(4);
        }
    }

    // Jump Check
    void JumpCheck()
    {
        if (this.gameObject.transform.position.y >= 2f)
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
            healthPoint[hp].GetComponent<SpriteRenderer>().sprite =hpImage;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("block"))
        {
            hp--;
        }

        if (collision.CompareTag("UpObj"))
        {
            animator.SetTrigger("hurt_u");
            gameManager.isOpening = true;
            backGroundManager.speed = 0;
            hp--;
        }
    }

    public void isOpeningfalse() 
    {
        gameManager.isOpening = false;
        backGroundManager.speed = 0.15f;
    }
}
