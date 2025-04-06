using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Activator : MonoBehaviour
{
    //scriptable objects for tracking of data
    public DayOfWeek dayofWeek;
    public TimeOfDay timeOfDay;

    //lists of NPC gameobjects for activation purposes
    public List<GameObject> allAvailableNPC = new List<GameObject>();

    public void ActivateDeactivateAll()
    {
        
        foreach (GameObject npc in allAvailableNPC)
        {
            //check if spawnable day matches current
            int dayNumber = dayofWeek.currentDay;
            int timeNumber = timeOfDay.currentTimeOfDay;

            // would be really cool if more dynamic, such as separating Day vs Night
            // from the Days ala, can be active Friday Day only, or Saturday Night only
            // 2d array maybe CVF 4-5-25
            // not enough time until launch and thesis to reconfigure

            bool dayTest = npc.GetComponent<NPC_Info>().daysList[dayNumber];
            bool timeTest = npc.GetComponent<NPC_Info>().timesList[timeNumber];

            if (!dayTest || !timeTest)
            {
                npc.SetActive(false);
            }
            else
            {
                npc.SetActive(true);
            }

        }
        
    }


}
