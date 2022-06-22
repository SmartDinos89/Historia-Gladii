using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject item;
    public GameObject Arrows;
    public Animator animator;
    public bool collected = false;
    Vector3 above; 
    private void Start()
    {
        above = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, gameObject.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(collected == false){
        if(other.tag == "Player"){

            collected = true;
            animator.Play("Open");
            Instantiate(item, above, transform.rotation);
            Arrows.SetActive(true); 
        }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(above, 1f);
    }
}
