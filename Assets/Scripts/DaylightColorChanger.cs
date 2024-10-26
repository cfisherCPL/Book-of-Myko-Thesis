using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DaylightColorChanger : MonoBehaviour
{
    public TimeOfDay timeOfDay;

    [SerializeField] public Light2D sunlight;

    Color morning = new Color(0.7f,0.7f,0.5f,1.0f);
    Color daytime = new Color(1.0f,1.0f,1.0f,1.0f);
    Color evening = new Color(0.7f,0.4f,0.1f,1.0f);
    Color night = new Color(0.1f,0.1f,0.15f,1.0f);
    Color midnight = new Color(.1f,.1f,.1f,1.0f);

   Color[] sunColors;


    void Awake()
    {
        sunColors = new Color[]{ morning, daytime, evening, night, midnight};
    }

    // Start is called before the first frame update
    void Start()
    {
        sunlight.color = sunColors[timeOfDay.currentTimeOfDay];
    }

    // Update is called once per frame
    void Update()
    {
        sunlight.color = sunColors[timeOfDay.currentTimeOfDay];

    }
}
