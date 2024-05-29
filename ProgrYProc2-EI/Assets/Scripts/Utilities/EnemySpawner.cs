using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject blackEnemyPrefab;
    public GameObject whiteEnemyPrefab;
    public GameObject redBulletPrefab;
    public GameObject orangeBulletPrefab;
    public float spawnDelay = 1f;
    public float spawnRadius = 3f;
    public float yOffset = 4f;
    private Transform player;

    private bool useSimpleShooting = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
        InvokeRepeating("ToggleShootingPattern", 3f, 3f);
    }

    void SpawnEnemy()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-spawnRadius, spawnRadius), yOffset, Random.Range(-spawnRadius, spawnRadius));
        Vector3 spawnPosition = player.position + randomOffset;

        GameObject enemyPrefab = Random.Range(0f, 1f) > 0.5f ? blackEnemyPrefab : whiteEnemyPrefab;
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        float fallDelay = Random.Range(0.5f, 1.5f);
        Rigidbody enemyRb = newEnemy.GetComponent<Rigidbody>();
        if (enemyRb != null)
        {
            enemyRb.velocity = Vector3.down * 5f;
            enemyRb.useGravity = false;
            Invoke("ActivateGravity", fallDelay);
        }

        IShootingPattern shootingPattern = newEnemy.GetComponent<IShootingPattern>();
        if (shootingPattern != null)
        {
            GameManager.Instance.RegisterShootingPattern(shootingPattern);
        }
    }

    void ActivateGravity()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                enemyRb.useGravity = true;
            }
        }
    }

    void ToggleShootingPattern()
    {
        useSimpleShooting = !useSimpleShooting;
        GameManager.Instance.CurrentBulletPrefab = useSimpleShooting ? redBulletPrefab : orangeBulletPrefab;
        GameManager.Instance.CurrentShootingPattern = useSimpleShooting ? typeof(SimpleShooting) : typeof(DobleShooting);
    }
}
