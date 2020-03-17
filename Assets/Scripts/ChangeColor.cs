using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject colorChanger;

    float intervalTime = 0.5f;

    float spendTime = 0f;

    // Update is called once per frame
    void Update()
    {
        spendTime += Time.deltaTime;
        if (spendTime > intervalTime)
        {
            colorChanger.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
            spendTime = 0f;
        }
    }
}
