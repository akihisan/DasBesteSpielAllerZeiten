using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sunLight;  // Reference to the Directional Light (Sun)
    public Color dayColor = Color.white;  // Color of the sun during the day
    public Color nightColor = Color.black;  // Color of the sun during the night

    void Start()
    {
        UpdateLightingBasedOnTime();
    }

    void Update()
    {
        // Update the lighting in case the system time changes while playing
        UpdateLightingBasedOnTime();
    }

    void UpdateLightingBasedOnTime()
    {
        // Get the system's current hour
        int currentHour = DateTime.Now.Hour;

        if (currentHour >= 6 && currentHour <= 18)  // 6 AM to 6 PM is day
        {
            SetDayTime();
        }
        else  // Night time otherwise
        {
            SetNightTime();
        }
    }

void SetDayTime()
{
    sunLight.intensity = Mathf.Lerp(sunLight.intensity, 1.0f, Time.deltaTime);
    sunLight.color = Color.Lerp(sunLight.color, dayColor, Time.deltaTime);
    RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, dayColor, Time.deltaTime);
}

void SetNightTime()
{
    sunLight.intensity = Mathf.Lerp(sunLight.intensity, 0.2f, Time.deltaTime);
    sunLight.color = Color.Lerp(sunLight.color, nightColor, Time.deltaTime);
    RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, nightColor, Time.deltaTime);
}

}
