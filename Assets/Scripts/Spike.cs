using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public PlayerScript player;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
             if(player.currentHealth <= 1 ){
                    player.TakeDamage(.5f);
            StartCoroutine(player.die());
        }else {
            player.TakeDamage(.5f);
        }
        }
    }
}
