
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExceptionHandler : MonoBehaviour
{
    private void Start()
    {
        try
        {
            InitializeGame();
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred during initialization: {ex.Message}");
        }
    }

    private void Update()
    {
        try
        {
            UpdateGame();
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred during update: {ex.Message}");
        }
    }

    private void InitializeGame()
    {        
        Debug.Log("Game Initialized Successfully");
    }

    private void UpdateGame()
    {      
        Debug.Log("Game Updated Successfully");
    }
}
