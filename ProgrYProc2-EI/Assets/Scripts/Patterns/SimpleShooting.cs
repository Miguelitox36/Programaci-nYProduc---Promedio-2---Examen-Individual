using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShooting : MonoBehaviour, IShootingPattern
{
    public void Shoot(Transform firePoint, GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
