using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Start()
    {
        Invoke("DestroyBullet", 3f);
    }

    public void Initialize()
    {
        GetComponent<Rigidbody>().velocity = Vector3.up * speed;
    }

    void DestroyBullet()
    {        
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage, this);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("EnemyAttack1") || other.CompareTag("EnemyAttack2"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
        if (IsStopped())
        {            
            Destroy(gameObject);
        }
    }

    bool IsStopped()
    {        
        return GetComponent<Rigidbody>().velocity.magnitude < 0.1f;
    }
}
