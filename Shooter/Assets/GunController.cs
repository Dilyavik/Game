using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //public Transform shootPoint; 
    public GameObject bulletPrefab; 



    public void Shoot(int damage, Transform shootPoint)
    {
        Vector3 shootDirection = transform.forward;
        
        // Создаем пулю и устанавливаем ее параметры
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.LookRotation(shootDirection));
        EnemyBullet bulletController = bullet.GetComponent<EnemyBullet>();
        bulletController.SetDamage(damage);

        Debug.Log("Bot Position: " + transform.position);
        Debug.Log("Shoot Point Position: " + shootPoint.position);
        Debug.Log("Shoot Direction: " + shootDirection);
    }
}
