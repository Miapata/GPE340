using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float seconds;
    public float minutes;

    public string timer;
    public TextMeshProUGUI textTime;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        seconds = Mathf.Clamp(seconds -= Time.deltaTime, 0, 60);
        minutes = Mathf.Clamp(minutes -= Time.deltaTime, 0, 99);

        FormatTime();
        textTime.text = timer;


    }

    void FormatTime()
    {
        Mathf.Floor(minutes / 60).ToString("0");
        Mathf.Floor(seconds % 60).ToString("0");

        timer = String.Format("{0}:{1}", minutes, seconds);

    }


}
