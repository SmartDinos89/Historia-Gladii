using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIngPOng : MonoBehaviour
{
    public Vector3 startPos;

    public bool upDown;
    public bool leftRight;
    public bool dead = false;

    
    public float moveDist = 5f;

    public float speed = 3f;
    // Start is called before the first frame update
    private void Start() {
        startPos = transform.position; 
    }
    public void PingPong()
    {
        if(leftRight)
        {
            transform.position = new Vector3(startPos.x + Mathf.PingPong(Time.time * speed, moveDist), transform.position.y, transform.position.z);
        }
        if(upDown)
        {
            transform.position = new Vector3(transform.position.x, startPos.y + Mathf.PingPong(Time.time * speed, moveDist), transform.position.z);      
        }
    }

    private void Update()
    {
        if(dead == false){
            PingPong();
        }
            
    }
}
