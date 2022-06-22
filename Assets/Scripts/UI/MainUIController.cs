using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    /// <summary>
    /// A simple controller for switching between UI panels.
    /// </summary>
    public class MainUIController : MonoBehaviour
    {
        public GameObject[] panels;
        public GameObject infoButton;
        public GameObject settings;
        public GameObject credits;
        public void SetActivePanel(int index)
        {
            for (var i = 0; i < panels.Length; i++)
            {
                var active = i == index;
                var g = panels[i];
                if (g.activeSelf != active){
                    g.SetActive(active); 
                    } 
            }
        }

        void OnEnable()
        {
            SetActivePanel(0);
        }

        private void Update() {
            if(panels[0].activeInHierarchy)
            {
                infoButton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                settings.transform.localScale = Vector3.one;
                credits.transform.localScale = Vector3.one;
            }
            else if(panels[1].activeInHierarchy)
            {
                settings.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                infoButton.transform.localScale = Vector3.one;
                credits.transform.localScale = Vector3.one;
            }
            else if(panels[2].activeInHierarchy)
            {
                credits.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                infoButton.transform.localScale = Vector3.one;
                settings.transform.localScale = Vector3.one;
            }
        }

    }
}