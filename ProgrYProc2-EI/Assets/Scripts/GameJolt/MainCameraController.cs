using GameJolt.API;
using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraController : MonoBehaviour
{    void Start()
    {
        GameJoltUI.Instance.ShowSignIn((bool isSignedIn) =>
        {
            if (isSignedIn)
            {
                Debug.Log("Se logueo correctamente");
                UnlockTrophy();
            }
            else
            {
                Debug.Log("Ocurrio un error.");
            }
        });
    }

    void UnlockTrophy()
    {
        Trophies.TryUnlock(234462, (trophyResult) =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }
}
