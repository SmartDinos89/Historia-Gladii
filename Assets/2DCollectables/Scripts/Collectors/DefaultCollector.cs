using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
    public class DefaultCollector : MonoBehaviour
    {
        public int numOfItemsCollected = 0;
        public Text Score;

        public Text Arrows;
        public int ArrowsNum;
        public PlayerScript player;
        public shoot shoot;

        public GameObject womanText;
        public GameObject end;
        private void Awake() {
            
        }
        public void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag == "Gem"){
                numOfItemsCollected += 1;
            Score.text = numOfItemsCollected.ToString();
            Destroy(collider.gameObject);
            } else if(collider.tag == "Heart"){
                if(player.currentHealth < player.maxHealth){
                    player.Heal(1);
            Destroy(collider.gameObject);
                }
            }
                else if(collider.tag == "Arrow"){
                ArrowsNum += 1;
                shoot.arrowsNum += 1;
            Arrows.text = ArrowsNum.ToString();
            Destroy(collider.gameObject);
                    
                } else if(collider.tag == "Key"){
                end.SetActive(true);
                womanText.SetActive(false);
                Destroy(collider.gameObject);
            }
            
        }
    }

