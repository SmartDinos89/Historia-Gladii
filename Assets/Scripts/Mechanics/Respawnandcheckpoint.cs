using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnandcheckpoint : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 respawnpoint;
    public PlayerScript player;
    void Start()
    {
        respawnpoint = transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Respawn"){
            respawnpoint = new Vector2(transform.position.x, transform.position.y + 2f);
        } else if(other.tag == "FallDetector") {
            if(player.Dead == false){
                StartCoroutine(player.TakeDamage(2f));
                respawn();
            }
            
            
        } 
    }

    public void respawn(){
        transform.position = respawnpoint;
    }
}
