using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject blackEnemyPrefab;
    public GameObject whiteEnemyPrefab;
    public float spawnInterval = 0.5f;
    public float spawnYPosition = 15f;
    public float spawnXMin = -10f;
    public float spawnXMax = 10f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float spawnXPosition = Random.Range(spawnXMin, spawnXMax);
            Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0);
                        
            GameObject enemyPrefab = Random.Range(0, 2) == 0 ? blackEnemyPrefab : whiteEnemyPrefab;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
