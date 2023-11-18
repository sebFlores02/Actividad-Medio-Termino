using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{

    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    private float minuteToRealTime = 1f;
    private float timer;

    /// <summary>
    /// This player controller class will update the events from the vehicle player.
    /// </summary>
    void Start()
    {
        Minute = 0;
        Hour = 0;
        timer = minuteToRealTime;
    }

    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Minute++;

            OnMinuteChanged?.Invoke();

            if (Minute >= 60)
            {
                Hour++;
                OnHourChanged?.Invoke();
                Minute = 0;
            }

            timer = minuteToRealTime;
        }
    }
}