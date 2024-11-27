using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public string mushName;
    public string flavorText;

    /// <summary>
    /// To better enable creation of mushrooms
    /// inside of the Unity inspector
    /// each data point is a selectable boolean
    /// if later mushrooms get added, this can be expanded
    ///
    /// /// 
    /// </summary>

    public List<bool> daysList = new List<bool>(7);
    public List<bool> timesList = new List<bool>(5);

    [Header("Days to Generate")]
    public bool monday;
    public bool tuesday;
    public bool wednesday;
    public bool thursday;
    public bool friday;
    public bool saturday;
    public bool sunday;

    [Header("Time of Day to Generate")]
    public bool morning;
    public bool day;
    public bool evening;
    public bool night;
    public bool midnight;

    [Header("Scenes to Generate")]
    public bool Grasslands;
    public bool SodHouse;
    public bool Forest;
    public bool GigaTree;
    public bool Mountains;
    public bool Cavern;

    [Header("Special Hints")]
    public string hint1;
    public string hint2;


    private void Awake()
    {
        //update the accessible list with the inspector chosen days that spawn
        daysList.Insert(0, monday);
        daysList.Insert(1, tuesday);
        daysList.Insert(2, wednesday);
        daysList.Insert(3, thursday);
        daysList.Insert(4, friday);
        daysList.Insert(5, saturday);
        daysList.Insert(6, sunday);

        //update the accessible list with the inspector chosen timess that spawn
        timesList.Insert(0, morning);
        timesList.Insert(1, day);
        timesList.Insert(2, evening);
        timesList.Insert(3, night);
        timesList.Insert(4, midnight);
    }
}
