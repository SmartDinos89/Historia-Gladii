using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PlayerScript player;
    public Transform attackPoint;

    public AudioSource sound;
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_RUN = "Run";
    const string PLAYER_JUMP = "Jump";
    const string PLAYER_ATTACK = "Attack";
    const string PLAYER_HURT = "Hurt";
    const string PLAYER_DEATH = "Death";
    private float attackDelay = 0.3f;
    public AudioClip attackSound;
    public LayerMask enemy;

    private void FixedUpdate() {
        if (player.isAttackPressed)
        {
            player.isAttackPressed = false;

            if (!player.isAttacking)
            {
                player.isAttacking = true;
               
                    player.ChangeAnimationState(PLAYER_ATTACK);
                    sound.PlayOneShot(attackSound);
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, .7f, enemy);
                    Invoke("AttackComplete", attackDelay);

                    for (int i = 0; i < hitEnemies.Length; i++)
                    {
                       hitEnemies[i].GetComponent<enemyController>().TakeDamage(1);
    
                    }

            }


        }
    }

    void AttackComplete()
    {
        player.isAttacking = false;
    }

    private void OnDrawGizmosSelected() {
        if(attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, .7f);
    }
}
