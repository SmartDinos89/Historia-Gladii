using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject ui;

    public bool main;
    public GameObject ui2;
    private void Awake()
    {
        if(main){
        Time.timeScale = 0;
        ui.SetActive(true);
        ui2.SetActive(true);
        } else {
            Time.timeScale = 1;
            ui2.SetActive(true);
        }
    }
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            if(ui.activeInHierarchy == false){
                ui.SetActive(true);
                Time.timeScale = 0;
            } else if(ui.activeInHierarchy){
                ui.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

}
