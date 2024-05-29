using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemy : Enemy
{
    private void Awake()
    {
        requiredBulletType = "white";
        movementPattern = new StraightMovement();
        shootingPattern = gameObject.AddComponent<SimpleShooting>();
    }
}
