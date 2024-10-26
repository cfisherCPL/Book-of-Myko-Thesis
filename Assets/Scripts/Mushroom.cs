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
    /// </summary>


    [Header("Days to Generate")]
    public bool monday;
    public bool tuesday;
    public bool wednesday;
    public bool thursday;
    public bool friday;
    public bool saturday;
    public bool sunday;

    [Header("Time of Day to Generate")]
    public bool day;
    public bool night;

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

}
