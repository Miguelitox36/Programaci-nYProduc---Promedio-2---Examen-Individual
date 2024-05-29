using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float verticalOffset = 4f;

    private void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(transform.position.x, player.position.y + verticalOffset, transform.position.z);
        }
    }
}
