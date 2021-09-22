using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    public float jumpForce;
    public float startSpeed;
    public float maxSpeed;
    public GameObject groundCheck;
    public LayerMask layerMask;
    private bool grounded;
    public static int life = 1;
    public float deathTime;
    
    void Awake()
    {
        life = 1;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Animation();
        Death();
    }
    void FixedUpdate()
    {
        grounded = Physics2D.CircleCast(groundCheck.transform.position, 0.9f, Vector2.down, 0.9f, layerMask);
        Run();
    }
    private void Run()
    {
        if(life>0)
        {
            rigidBody.AddForce (Vector3.right * startSpeed);
            if(rigidBody.velocity.x>maxSpeed)
            {
                rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x)*maxSpeed, rigidBody.velocity.y);
            }
        } 
    }
    public void Jump()
    {
        if(grounded && life>0)
        {
           rigidBody.AddForce(Vector3.up * jumpForce);
        }
    }

    private void Animation()
    {
        if(grounded)
        {
            animator.SetBool("JumpFall", false);
            if(rigidBody.velocity.x>0)
            {
                animator.SetFloat("Speed", rigidBody.velocity.x);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
        }
        else
        {
            animator.SetBool("JumpFall", true);
        }
        if(life<=0)
        {
            animator.SetBool("Death", true);
        }
    }
    private void Death()
    {
        if(life<=0)
        {
            rigidBody.velocity = new Vector3(0,0,0);
            deathTime-=Time.deltaTime;
            if(deathTime<0)
            {
                UIController.GameOver("Sorry, Dino ate too many purple mushrooms and can't run anymore...");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color  = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, 0.9f);
    }
}
