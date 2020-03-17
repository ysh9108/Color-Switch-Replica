using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public static void StageClear()
    {
        string nextStageName = "Stage_" + (int.Parse(GetSceneName().Split('_')[1]) + 1).ToString();
        if (nextStageName == "Stage_5")
        {
            GameObject.FindWithTag("StageCanvas").GetComponent<ClearScreen>().OnClearMessage();
        }
        else
        {
            GameObject.FindWithTag("StageCanvas").GetComponent<ClearScreen>().OnClearMessage();
        }
    }

    public static void NextStage()
    {
        string nextStageName = "Stage_" + (int.Parse(GetSceneName().Split('_')[1]) + 1).ToString();
        SceneManager.LoadScene(nextStageName);
    }

    public static void LoadMenu()
    {
        //Debug.Log("TODO load menu scene...");
        SceneManager.LoadScene("Menu");
    }
}
