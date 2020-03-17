using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneController.StartGame();
    }

    public void ExitGame()
    {
        Debug.Log("Exitting Game");
        Application.Quit();
    }
}
