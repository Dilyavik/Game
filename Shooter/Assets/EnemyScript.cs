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
    public GameOverUIManager gameOverUIManager;


    private void Start()
    {
        currentHealth = maxHP;
        UpdateHealthBar();
    }

    private void Update()
    {
        // Проверяем дистанцию до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootingRange)
        {
            // Поворачиваем бота в сторону игрока
            Vector3 targetDirection = player.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetDirection);

            // Стреляем с заданной периодичностью
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
        // Вызываем метод стрельбы у объекта "GunController"
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


        if (currentHealth <= 0)
        {
            DestroyEnemy();
            gameOverUIManager.ShowGameOver();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
