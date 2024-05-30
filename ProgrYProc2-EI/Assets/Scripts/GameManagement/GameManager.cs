using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject CurrentBulletPrefab { get; set; }
    public System.Type CurrentShootingPattern { get; set; }

    private List<IShootingPattern> shootingPatterns = new List<IShootingPattern>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterShootingPattern(IShootingPattern shootingPattern)
    {
        shootingPatterns.Add(shootingPattern);
    }

    public void UpdateShootingPatterns()
    {
        foreach (var shootingPattern in shootingPatterns)
        {
            if (CurrentShootingPattern == typeof(SimpleShooting))
            {
                shootingPattern.Shoot(transform, CurrentBulletPrefab);
            }
            else if (CurrentShootingPattern == typeof(DobleShooting))
            {
                shootingPattern.Shoot(transform, CurrentBulletPrefab);
            }
        }
    }
}
