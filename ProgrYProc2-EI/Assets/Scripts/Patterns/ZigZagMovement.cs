using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : IMovementPattern
{
    public void Move(Transform transform)
    {        
        transform.position += new Vector3(Mathf.Sin(Time.time * 5) * 0.1f, -0.1f, 0);
    }
}
