using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	private void Update() {
		if(Input.GetKeyDown(KeyCode.H)){
			TakeDamage(1);
		}
	}


	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
