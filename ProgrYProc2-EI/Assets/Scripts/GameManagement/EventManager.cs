using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action OnEnemyKilled;

    public static void TriggerEnemyKilled()
    {
        OnEnemyKilled?.Invoke();
    }
}
