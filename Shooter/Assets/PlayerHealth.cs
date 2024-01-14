using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameOverUIManager manager;
    public int maxHealth = 100;
    private int currentHealth;


    public Slider healthBar;



    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        Destroy(gameObject);
        manager.ShowGameOver();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {

            healthBar.value = (float)currentHealth;
        }
    }


}
