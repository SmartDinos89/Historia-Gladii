using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private GameObject score;
    public TMP_Text text;
    private void Awake() {
        score = GameObject.FindGameObjectWithTag("Canvas");
        text.text = "Your Score Was: " + score.GetComponent<Text>().text + ".";
        Destroy(score.transform.parent.gameObject);
    }
}
