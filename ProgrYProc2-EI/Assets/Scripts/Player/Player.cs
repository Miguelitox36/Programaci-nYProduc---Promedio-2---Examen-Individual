using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{    
    public GameObject blackBulletPrefab;
    public GameObject whiteBulletPrefab;
    public Transform shootPoint;

    private float aliveTime = 0f;
    private bool hasSurvived5Seconds = false;
    private bool hasSurvived10Seconds = false;

    void Update()
    {
        Move(Vector3.zero);

        if (Input.GetMouseButtonDown(0)) 
        {
            Fire("black");
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            Fire("white");
        }

        aliveTime += Time.deltaTime;

        if (!hasSurvived5Seconds && aliveTime >= 5f)
        {
            hasSurvived5Seconds = true;
            Trophies.TryUnlock(234464);
        }
                
        if (!hasSurvived10Seconds && aliveTime >= 10f)
        {
            hasSurvived10Seconds = true;
            Trophies.TryUnlock(234465);
        }
    }

    public override void Move(Vector3 direction)
    {        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
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
        Trophies.TryUnlock(234466, (trophyResult) =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack1"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("EnemyAttack2"))
        {
            TakeDamage(2);
            Destroy(other.gameObject);
        }
    }
}
