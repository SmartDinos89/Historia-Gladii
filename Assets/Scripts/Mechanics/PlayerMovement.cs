using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public Animator animator;
    public Respawnandcheckpoint respawn;

    public Rigidbody2D rb;

    float horizontalMove = 0f;
    bool jump = false;
    public HealthBar healthBar;
    bool dead = false;
    bool hurt = false;
    public float speed = 40f;
    public Health health;

    void Awake(){
        dead = false;
    }
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        jump = Input.GetButton("Jump");

        if(controller.m_Grounded == true){
            animator.SetBool("Grounded", true);
        } else {
            animator.SetBool("Grounded", false);
        }

    }
    
    private void FixedUpdate() {
        if(dead == false && hurt == false){
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        }
        
        if(horizontalMove != 0 && controller.m_Grounded && hurt == false)
        {
        animator.SetFloat("Speed", 1);
        } else {
        animator.SetFloat("Speed", 0);
        }

        if(jump ){
            animator.SetBool("Jumped", true);
        } else {
            animator.SetBool("Jumped", false);
        }

    }

    public IEnumerator hurts(){
        rb.velocity = Vector2.zero;
        hurt = true;
        animator.SetTrigger("hurt");
        yield return new WaitForSeconds(.1f);
        health.TakeDamage(1);
        Physics2D.IgnoreLayerCollision(6,7, true);
        yield return new WaitForSeconds(.625f);
        Physics2D.IgnoreLayerCollision(6,7, false);
        hurt = false;
    }

    public IEnumerator die(){
        rb.velocity = Vector2.zero;
        dead = true;
        animator.SetTrigger("dead");
        yield return new WaitForSeconds(1f);
        healthBar.SetMaxHealth(health.maxHealth);
        transform.position = respawn.respawnpoint;
        dead = false;
    }

}
