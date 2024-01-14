using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; 



    public void Shoot(int damage, Transform shootPoint)
    {
        Vector3 shootDirection = transform.forward;
        
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.LookRotation(shootDirection));
        EnemyBullet bulletController = bullet.GetComponent<EnemyBullet>();
        bulletController.SetDamage(damage);
    }
}
