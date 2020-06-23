using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    public float time = 0;
    int minute = 0;
    int totalMinutes = 0;
    int hour = 9;
    int day = 1;
    //public float day = 0;

    //float hoursInDay = 24.0f;
    //float hoursOfSun = 12.0f;
    public float dayTime = 0;

    [Range(0.1f, 20)]
    [SerializeField]
    public float DayLengthModifier = 1;

    public Text clockText;
    string hourString;
    string minuteString;
    string clockString;


    void FixedUpdate()
    {
        time += (Time.deltaTime *24) / DayLengthModifier;



        Clock();
        DayTime();
        clockText.text = ClockVisualization();
    }

    string ClockVisualization()
    {
        if (Hour() < 10)
            hourString = "0" + Hour();
        else
            hourString = Hour().ToString();

        if (Minute() < 10)
            minuteString = "0" + Minute();
        else
            minuteString = Minute().ToString();

        clockString = hourString + ":" + minuteString;

        return clockString;
    }

    //Time for a whole to pass. 1440 seconds / timeModifier
    public float Clock()
    {
        Minute();
        Hour();
        Day();


        return time;
    }

    public float Minute()
    {
        minute = (int)time - totalMinutes;

        if (minute >= 60)
        {
            ++hour;
            totalMinutes += 60;
            minute = 0;
        }

        return minute;
    }

    public float Hour()
    {
        if(hour >= 24)
        {
            hour = 0;
            ++day;
        }

        return hour;
    }

    public float Day()
    {
        if (day >= 30)
        {
            day = 1;
        }

        return hour;
    }

    public float DayTime()
    {
        dayTime = time;

        return dayTime;
    }
}
