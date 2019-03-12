﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float countDownTime;
    private float seconds;
    private float minutes;

    public string timer;
    public TextMeshProUGUI textTime;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        seconds = Mathf.FloorToInt(seconds);
        minutes = Mathf.FloorToInt(minutes);
        countDownTime -= Time.deltaTime;
        FormatTime();
        textTime.text = timer;


    }

    void FormatTime()
    {
        minutes = Mathf.Floor(countDownTime / 60);
        seconds =Mathf.Floor(countDownTime - minutes * 60);

        timer = String.Format("{0}:{1}", minutes, seconds);

    }


}
