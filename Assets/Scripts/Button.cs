using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Button : MonoBehaviour
{

    public GameObject black;
    public GameObject start;
    public GameObject quit;
    public bool lose;

    public GameObject cont;
    // Start is called before the first frame update
    public void StartGame()
    {
        if(!lose){
        black.SetActive(true);
        cont.SetActive(true);
        start.SetActive(false);
        quit.SetActive(false);
        }
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void continues(){
        SceneManager.LoadScene(1);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
