using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobleShooting : MonoBehaviour, IShootingPattern
{
    public void Shoot(Transform enemyTransform, GameObject bulletPrefab)
    {
        Vector3 offset = new Vector3(-0.5f, 0, 0);
        Instantiate(bulletPrefab, enemyTransform.position + offset, Quaternion.identity);
        Instantiate(bulletPrefab, enemyTransform.position - offset, Quaternion.identity);
    }
}