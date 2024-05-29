using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : Enemy
{
    private void Awake()
    {
        requiredBulletType = "black";
        movementPattern = new StraightMovement();
        shootingPattern = gameObject.AddComponent<SimpleShooting>();
    }
}
