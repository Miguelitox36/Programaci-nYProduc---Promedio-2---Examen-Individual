using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : IMovementPattern
{
    public void Move(Transform transform)
    {
        transform.position += Vector3.down * Time.deltaTime;
    }
}
