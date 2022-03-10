using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTrigger : MonoBehaviour
{
    public shoot Shoot;
    public GameObject gb;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Destroy(gb, 0);
            Shoot.arrowsNum++;
        }
    }
}
