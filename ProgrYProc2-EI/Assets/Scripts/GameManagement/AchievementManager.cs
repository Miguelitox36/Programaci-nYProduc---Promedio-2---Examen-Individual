using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnEnemyKilled += CheckAchievements;
    }

    private void OnDisable()
    {
        EventManager.OnEnemyKilled -= CheckAchievements;
    }

    private void CheckAchievements()
    {
        // Implement logic to check and unlock achievements
    }
}
