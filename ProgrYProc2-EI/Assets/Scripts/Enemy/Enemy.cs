using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public string requiredBulletType;
    public IMovementPattern movementPattern;
    public IShootingPattern shootingPattern;

    private void Update()
    {
        if (movementPattern != null)
            movementPattern.Move(transform);

        if (shootingPattern != null)
            shootingPattern.Shoot(transform, gameObject);
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
}
