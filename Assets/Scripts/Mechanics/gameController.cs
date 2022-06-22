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
        Time.timeScale = 0;
        ui.SetActive(true);
        ui2.SetActive(false);

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(ui.activeInHierarchy == false){
                ui.SetActive(true);
                ui2.SetActive(false);
                Time.timeScale = 0;
            } else if(ui.activeInHierarchy){
                DisableUI();
            }
        }
    }
    public void DisableUI()
    {
    ui.SetActive(false);
    ui2.SetActive(true);
    Time.timeScale = 1;
    }

}
