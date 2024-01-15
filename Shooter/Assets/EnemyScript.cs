using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    public int maxHP = 100;
    public Slider healthBar;
    private int currentHealth;

    public Transform player;
    public float shootingRange = 30f;
    public float shootingCooldown = 2f;
    public int damage = 10;
    public Transform gunTransform;
    public Transform shootPoint;

    private float shootingTimer = 0f;


    private void Start()
    {
        currentHealth = maxHP;
        UpdateHealthBar();
    }

    private void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootingRange)
        {

            Vector3 targetDirection = player.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetDirection);


            shootingTimer -= Time.deltaTime;
            if (shootingTimer <= 0f)
            {
                Shoot();
                shootingTimer = shootingCooldown;
            }
        }
    }

    void Shoot()
    {

        gunTransform.GetComponent<GunController>().Shoot(damage, shootPoint);
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {

            healthBar.value = (float)currentHealth;
        }
    }



    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        UpdateHealthBar();

        int loseCount = PlayerPrefs.GetInt("win");
        if (currentHealth <= 0)
        {
            DestroyEnemy();

            

            PlayerPrefs.SetInt("win", loseCount + 1);

            PlayerPrefs.Save();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
