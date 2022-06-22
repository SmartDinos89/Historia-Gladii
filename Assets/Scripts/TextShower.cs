using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShower : MonoBehaviour
{
    [SerializeField] GameObject Text;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            Text.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Text.SetActive(false);
    }
}
