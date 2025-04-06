using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Info : MonoBehaviour
{
    public List<bool> daysList = new List<bool>(7);
    public List<bool> timesList = new List<bool>(5);

    public bool gaveSpecialMushroom;
    [SerializeField] public GameObject specialMushroom;
    [SerializeField] public Transform mushSpawnLoc;

    [Header("Days Active")]
    public bool monday;
    public bool tuesday;
    public bool wednesday;
    public bool thursday;
    public bool friday;
    public bool saturday;
    public bool sunday;

    [Header("Times Active")]
    public bool morning;
    public bool day;
    public bool evening;
    public bool night;
    public bool midnight;

     private void Start()
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


    public void GiveSpecialMushroom()
    {
        if (!gaveSpecialMushroom)
        {
            GameObject giftMush = Instantiate(specialMushroom, mushSpawnLoc.position, mushSpawnLoc.rotation, this.transform);
            gaveSpecialMushroom = true;
        }
    }
}
