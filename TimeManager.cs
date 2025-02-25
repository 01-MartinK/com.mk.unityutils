using System;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public int minuteValue;
        public int hourValue;
    }

    public int minuteTickTime;
    public int hourTickTime;
    public int dayTickTime;

    public TextMeshProUGUI debugTimeInfo;

    public static float time;
    public static int minute;
    public static int hour;
    public static int day;

    public static event EventHandler<OnTickEventArgs> OnMinuteTick;
    public static event EventHandler<OnTickEventArgs> OnHourTick;
    public static event EventHandler<OnTickEventArgs> OnDayTick;

    private void Update()
    {
        debugTimeInfo.text = $"time: {Mathf.Round(time)}\nminute: {minute}\nhour: {hour}\nday: {day}";

        time += Time.deltaTime;

        if (time >= minuteTickTime)
        {
            time = 0;
            minute++;
            OnMinuteTick?.Invoke(this, new OnTickEventArgs { minuteValue = minute, hourValue = hour });
        }

        if (minute >= hourTickTime)
        {
            minute = 0;
            hour++;
            OnHourTick?.Invoke(this, new OnTickEventArgs { minuteValue = minute, hourValue = hour });
        }

        if (hour >= dayTickTime)
        {
            hour = 0;
            day++;
            OnDayTick?.Invoke(this, new OnTickEventArgs { minuteValue = minute, hourValue = hour });
        }
    }

    public static int GetTime()
    {
        return int.Parse($"{hour}{minute}");
    }
}
