using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    
    private void Start() {
        rb.velocity = transform.right * speed;
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != "Player"){
            Destroy(gameObject, 0);
        }
        
    }
}
