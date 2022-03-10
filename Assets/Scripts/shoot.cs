using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Shootpoint;
    public GameObject bullet;
    public Text Arrows;
    public int arrowsNum;
    private bool allowfire = true;

    // Update is called once per frame
    void Update()
    {
            if(Input.GetButtonDown("Fire2") && arrowsNum > 0){
            StartCoroutine(Fire());
            }
    }

    IEnumerator Fire()
    {
        
            allowfire = false;
            arrowsNum--;
            Arrows.text = arrowsNum.ToString();
            Instantiate(bullet, Shootpoint.position, Shootpoint.rotation);
            yield return new WaitForSeconds(.8f);
            allowfire = true;
            
     
    }
}
