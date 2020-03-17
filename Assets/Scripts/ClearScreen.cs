using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    public static bool GameIsClear = false;

    public GameObject ClearUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && GameIsClear)
        {
            OffClearMessage();
            int currentStage = int.Parse(SceneController.GetSceneName().Split('_')[1]);
            if (currentStage != 4)
            {
                SceneController.NextStage();
            }
            else
            {
                SceneController.LoadMenu();
            }
        }
    }

    public void OnClearMessage()
    {
        ClearUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsClear = true;
    }

    void OffClearMessage()
    {
        ClearUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
