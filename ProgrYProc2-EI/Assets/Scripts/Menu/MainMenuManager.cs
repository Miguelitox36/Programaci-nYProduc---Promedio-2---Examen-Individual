using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Trophies.TryUnlock(234463, (trophyResult) =>
        {
            SceneManager.LoadScene("Level1");
        });
    }

    public void QuitGame()
    {
        Trophies.TryUnlock(234467, (trophyResult) =>
        {
            Application.Quit();
        });       
    }
}
