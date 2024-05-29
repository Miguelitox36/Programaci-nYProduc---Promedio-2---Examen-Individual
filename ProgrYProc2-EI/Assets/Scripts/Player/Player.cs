using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public float speed = 5f;
    public GameObject blackBulletPrefab;
    public GameObject whiteBulletPrefab;
    public Transform shootPoint;

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) 
        {
            Fire("black");
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            Fire("white");
        }
    }

    public void Fire(string bulletType)
    {
        GameObject bullet = null;
        if (bulletType == "black")
        {
            bullet = Instantiate(blackBulletPrefab, shootPoint.position, Quaternion.identity);
        }
        else if (bulletType == "white")
        {
            bullet = Instantiate(whiteBulletPrefab, shootPoint.position, Quaternion.identity);
        }
        bullet.GetComponent<Bullet>().Initialize();
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
