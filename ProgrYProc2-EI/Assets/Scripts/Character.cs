using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health;

    public abstract void TakeDamage(int damage);

    public virtual void Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
