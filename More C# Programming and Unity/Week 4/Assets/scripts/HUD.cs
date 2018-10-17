using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for HUD
/// </summary>
public class HUD : MonoBehaviour
{

    [SerializeField]
    Text text;

    bool timerIsRunning = true;

    float elapsedSeconds = 0;

    // Use this for initialization
    void Start()
    {
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            elapsedSeconds += Time.deltaTime;
            text.text = ((int)elapsedSeconds).ToString();
        }

    }

    public void StopGameTimer()
    {
        timerIsRunning = false;
    }
}
