using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float bulletLife = 3f;

    public float speed = 10f;


    private void Start()
    {
        //GetComponent<Rigidbody>().velocity= transform.forward

        Destroy(gameObject, bulletLife);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyScript enemyScript = GetComponent<EnemyScript>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);
                Destroy(collision.gameObject);
            }
        }

        //Destroy(collision.gameObject);
        //Destroy(gameObject);

    }



    void OnTriggerEnter(Collider other)
    {

        if (other.tag =="Enemy")
        {
            EnemyScript enemyScript = other.GetComponent<EnemyScript>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }


}
