using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Camera mainCamera;
    public Transform spawnBullet;

    public float shootForce;
    public float speed;




    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKey(KeyCode.Mouse0))
            Shoot();
    }


    private void Shoot()
    {
        

        GameObject bullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = spawnBullet.forward * speed;
        
    }
}
