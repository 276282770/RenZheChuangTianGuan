using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=50;
    public float jump = 10;
    
    public int invincibleTime = 2;


    Animator anim;
    Rigidbody2D rig;
    int direction = 1;
    bool canJump = true;
    public bool invincible = false;  //无敌状态
    float invincibleTimeNow = 0;
    float jumpRate = 0.2f;
    float jumpTime = 0;


    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RunRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RunLeft();
            rig.MovePosition( new Vector2(5,0 ));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Idle();
        }
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Die();
        //}

        if (invincible)
        {
            invincibleTimeNow -= Time.deltaTime;
            if (invincibleTimeNow <= 0)
            {
                SetInvincible(false);
            }
        }
        if (jumpTime>0)
        {
            jumpTime -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "RightWall"|| collision.gameObject.name == "LeftWall")
        //{
        //    ChangeDirection();
        //}
        canJump = true;
        //Debug.Log("-------"+collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "DieLine")
        {
            GameManager.Instance.GameOver();
        }
    }
    public void ChangeDirection()
    {
        direction = -direction;
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        render.flipX = direction<0;
    }
    public void Die()
    {
        anim.SetBool("Die",true);
    }
    public void Jump()
    {
        if (!canJump||!GameManager.Instance.gamming)
            return;
        if (jumpTime > 0)
            return;
        jumpTime = jumpRate;
        if (rig.velocity.y == 0)
        {
            rig.velocity = new Vector2(0, jump);
        }

        //rig.AddForce(Vector2.up * jumpFocrce);

        anim.SetTrigger("Jump");
        canJump = false;
    }
    public void Run()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime*direction);
        anim.SetBool("Run", true);
    }
    public void RunRight()
    {
        direction = 1;
        GetComponent<SpriteRenderer>().flipX = false;
        Run();
    }
    public void RunLeft()
    {
        direction = -1;
        GetComponent<SpriteRenderer>().flipX = true;
        Run();
    }

    public void Idle()
    {
        anim.SetBool("Run",false);
    }


    /// <summary>
    /// 设置无敌状态
    /// </summary>
    /// <param name="b">是否无敌</param>
    public void SetInvincible(bool b)
    {
        if (b)
        {
            invincibleTimeNow = invincibleTime;
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0,0.6f);
            invincible = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            invincible = false;
        }

    }
}
