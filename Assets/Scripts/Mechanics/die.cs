using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class die : MonoBehaviour
{
    GameObject gb;

    private void Start() {
        gb = GetComponent<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "FallDetector" || other.tag  == "Spike"){
            Destroy(gb);
        }
    }
}
