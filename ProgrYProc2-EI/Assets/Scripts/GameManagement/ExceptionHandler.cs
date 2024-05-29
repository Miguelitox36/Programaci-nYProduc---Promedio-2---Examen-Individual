
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
            
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred: {ex.Message}");
        }
    }
}
