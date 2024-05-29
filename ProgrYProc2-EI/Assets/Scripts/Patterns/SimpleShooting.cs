using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShooting : MonoBehaviour, IShootingPattern
{
    public void Shoot(Transform enemyTransform, GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
    }
}
