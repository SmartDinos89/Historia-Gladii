using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public Animator animator;
    public PlayerScript player;
    public SpriteRenderer sr;
    public PIngPOng pingPong;
    public int health = 3;
    bool dead;

    // Start is called before the first frame update
    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }
    public IEnumerator Die(){
        if(gameObject != null){
            sr.color = new Color(255f, 0f, 0f, 1f);
        Physics2D.IgnoreLayerCollision(6,7,true); 
        yield return new WaitForSeconds(.6f);
        animator.Play("EnemHurt");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length/3);
        animator.Play("EnemDed");   
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject, 0);
        }
    }

    private void Update() {
        if(health <= 0 && dead == false){
            StartCoroutine(Die());
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(dead == false){
        if(other.tag == "Player"){
                if(player.currentHealth <= 0 ){
                    if(player.Dead == false){
                      dead = true;  
                StartCoroutine(player.die());
                
            }
        }else {
            player.TakeDamage(.5f);
        }
        }
        if(other.tag == "Arrow"){
            StartCoroutine(TakeDamage(1));
        }
        }
    }


    private void FixedUpdate() {
        if(dead == false){
            pingPong.PingPong();
        }
        }
    public IEnumerator TakeDamage(int damage){
        health -= 1;
        sr.color = new Color(255f, 0f, 0f, 1f);
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(.6f);
        animator.Play("EnemHurt");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length / 3);
        animator.Play("EnemRun");
        sr.color = new Color(255f, 255f, 255f, 1f);
    }
}
