using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBullet : Bullet
{
    void Update()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);


        if (IsStopped())
        {

            Destroy(gameObject);
        }
    }

    bool IsStopped()
    {

        return GetComponent<Rigidbody>().velocity.magnitude < 0.1f;
    }
}
