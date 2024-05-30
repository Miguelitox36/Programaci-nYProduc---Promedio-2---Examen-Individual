using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public string requiredBulletType;
    public IMovementPattern movementPattern;
    public IShootingPattern shootingPattern;
    public Transform firePoint;    
    private float shootCooldown = 0.5f;
    private float nextShootTime;
    private int shotCounter = 0;

    void Start()
    {
        nextShootTime = Time.time + shootCooldown;
    }

    void Update()
    {
        Move(Vector3.down);

        if (Time.time >= nextShootTime)
        {   
            AlternateShoot();
            nextShootTime = Time.time + shootCooldown;
        }
    }

    private void AlternateShoot()
    {
        if (shotCounter == 0 || shotCounter == 1)
        {
            Shoot1();
        }
        else
        {
            Shoot2();
        }

        shotCounter = (shotCounter + 2) % 4;
    }

    public abstract void Shoot1();
    public abstract void Shoot2();

    public override void Move(Vector3 direction)
    {
        movementPattern.Move(transform);
    }

    public override void TakeDamage(int damage)
    {        
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage, Bullet bullet)
    {
        if ((requiredBulletType == "black" && bullet is BlackBullet) || (requiredBulletType == "white" && bullet is WhiteBullet))
        {
            TakeDamage(damage);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        EventManager.TriggerEnemyKilled();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }
}
