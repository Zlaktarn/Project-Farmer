using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLightScript : MonoBehaviour
{
    Light sun;
    Transform sunPosition;
    Quaternion sunRotation;
    Vector3 rotationVector = new Vector3(50,0,0);

    public ClockScript Clock;

    
    public float sunIntensity;

    [Header("Dawn Time")]
    public bool dawnBool = false;
    [SerializeField]
    float dawnStart = 6.0f;
    [SerializeField]
    float dawnEnd = 9.0f;

    [Header("Dusk Time")]
    public bool duskBool = false;
    [SerializeField]
    float duskStart = 19.0f;
    [SerializeField]
    float duskEnd = 22.0f;

    void Start()
    {
        sun = gameObject.GetComponent<Light>();
        sunPosition = gameObject.GetComponent<Transform>();

        //hoursOfSun = duskEnd - dawnStart;
    }

    void Update()
    {
        DayManager();
    }

    void DayManager()
    {
        float t = Time.deltaTime / Clock.DayLengthModifier;

        DaylightManager(t);
        sunPosition.rotation = SunRotation(Clock.DayTime());
    }

    void DaylightManager(float t)
    {

        if (Clock.Hour() > dawnStart && Clock.Hour() < dawnEnd)
        {
            if (sunIntensity < 1)
            {
                sunIntensity += DawnLight(t);

                if (sunIntensity >= 1)
                    sunIntensity = 1;
            }

        }

        if (Clock.Hour() > duskStart && Clock.Hour() < duskEnd)
        {
            if (sunIntensity > 0)
            {
                sunIntensity += DuskLight(t);
                if (sunIntensity <= 0)
                    sunIntensity = 0;
            }
        }
        if(Clock.Hour() < duskStart && Clock.Hour() >= dawnEnd)
        {
            sunIntensity = 1;
        }

        sun.intensity = sunIntensity;
    }

    Quaternion SunRotation(float t)
    {
        float modifier = 360.0f / 1440.0f;
        Quaternion sunRotation;
        rotationVector.y = t;
        sunRotation = Quaternion.Euler(rotationVector * modifier);

        return sunRotation;
    }

    float DawnLight(float t)
    {
        float dawn = 0;
        dawn += 1 / (dawnEnd - dawnStart) * t;

        return dawn;
    }

    float DuskLight(float t)
    {
        float dusk = 0;
        dusk += 1 / (duskStart - duskEnd) * t;

        return dusk;
    }
}
