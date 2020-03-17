using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    private int currentStage = 0;

    public float[] intervalObjectDistance = { 4, 9, 16 };
    public float[] circleScale = { 1, 4, 8 };

    public GameObject prefabCircle;
    public GameObject prefabColorChanger;
    public GameObject prefabStageChanger;

    private GameObject[] stagePrefabs;

    private enum StageObject
    {
        CIRCLE,
        COLOR_CHNAGER,
        STAGE_CHANGER
    };

    public void InitializeGame()
    {
        Debug.Log("게임 Init");
        stagePrefabs = new GameObject[3] { prefabCircle, prefabColorChanger, prefabStageChanger};
        currentStage = GetCurrentStage();
    }

    public int GetCurrentStage()
    {
        return int.Parse(SceneController.GetSceneName().Split('_')[1]); 
    }

    public void StartStage()
    {
        Debug.Log("Stage Start " + (currentStage).ToString());
        BuildStage();
    }

    public void StageClear()
    {
        Debug.Log("Stage Clear " + (currentStage).ToString() + " !!!!");
        SceneController.StageClear();
    }

    private void BuildStage()
    {
        ArrayList stageObjs = new ArrayList();

        float y = 0f;
        int numObj = currentStage + 3;
        //int numObj = 1;
        int maxCircle = currentStage < intervalObjectDistance.Length ? currentStage : intervalObjectDistance.Length;
        Debug.Log("maxCircle : " + maxCircle.ToString());

        for (int layer = 0; layer < numObj; layer++)
        {
            int numCircle = Random.Range(1, maxCircle + 1);
            // Debug.Log("numCircle : " + numCircle.ToString());

            y += intervalObjectDistance[numCircle - 1];

            for (int c = 0; c < numCircle; c++)
            {
                // CIRCLE
                GameObject circle = Instantiate(stagePrefabs[(int)StageObject.CIRCLE], new Vector3(0, y, 0), Quaternion.identity);
                circle.transform.localScale = new Vector3(circleScale[c], circleScale[c], 0);
                float speed = 0f;
                float sign = Random.Range(0, 2) == 1 ? 1f : -1f;
                while (speed == 0)
                {
                    speed = Random.Range(60, 100 + c * 15) * sign;
                }
                circle.GetComponent<Rotator>().speed = speed;
                stageObjs.Add(circle);
            }

            y += intervalObjectDistance[numCircle - 1];
            if (layer != numObj - 1)
            {
                // COLOR_CHNAGER
                stageObjs.Add(Instantiate(stagePrefabs[(int)StageObject.COLOR_CHNAGER], new Vector3(0, y, 0), Quaternion.identity));
            }
            else
            {
                // STAGE_CHANGER
                stageObjs.Add(Instantiate(stagePrefabs[(int)StageObject.STAGE_CHANGER], new Vector3(0, y, 0), Quaternion.identity));
            }
        }
    }
}
