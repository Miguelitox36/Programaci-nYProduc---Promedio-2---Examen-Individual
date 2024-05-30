using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootingPattern
{
    void Shoot(Transform enemyTransform, GameObject bulletPrefab);
}
