using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementPattern
{
    void Move(Transform transform);
}
