using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : Enemy
{
    public GameObject bulletPrefabShoot1;
    public GameObject bulletPrefabShoot2;

    private void Awake()
    {
        requiredBulletType = "black";
        movementPattern = new StraightMovement();
        shootingPattern = gameObject.AddComponent<SimpleShooting>();
        firePoint = transform.Find("FirePoint");        
    }

    public override void Move(Vector3 direction)
    {
        movementPattern.Move(transform);
    }

    public override void Shoot1()
    {
        if (firePoint != null && bulletPrefabShoot1 != null)
        {
            shootingPattern.Shoot(firePoint, bulletPrefabShoot1);
        }
    }
    
    public override void Shoot2()
    {
        if (firePoint != null && bulletPrefabShoot2 != null)
        {
            shootingPattern.Shoot(firePoint, bulletPrefabShoot2);
        }
    }
}
