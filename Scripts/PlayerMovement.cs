using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private bool grounded;
    private void Awake()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }
    
    private void Move()
    {
        //Move
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        
        //Flip
        if (horizontalInput > 0f)
        {
            transform.localScale = new Vector3(6, 6, 6);
        }
        else if (horizontalInput < 0f)
        {
            transform.localScale = new Vector3(-6, 6, 6);
        }
        
        

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded",grounded);
    }

    private void Jump()
    {
        
        //Jump
        if (Input.GetKey(KeyCode.Space) && grounded) 
        {
            SoundManage.instance.Play(SoundManage.SoundName.Jump);
            rb.velocity = new Vector2(rb.velocity.x, speed);
            anim.SetTrigger("jump");
            grounded = false;

        }

        //Jump High & Low
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        else if (col.gameObject.tag == "Skill")
        {
            grounded = true;
            Destroy(col.gameObject,5f);
        }
    }
    
}
