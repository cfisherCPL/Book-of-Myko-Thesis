using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Spawner_Outside : MonoBehaviour
{
    //scriptable objects for tracking of data
    public DayOfWeek dayofWeek;
    public TimeOfDay timeOfDay;
    public AlreadySpawned mushSpawned;
    
    //lists of objects for spawning purposes
    public List<GameObject> allPotentialSpawns = new List<GameObject>();
    public List<GameObject> spawnLocations = new List<GameObject>();
    public List<GameObject> allLocationMushrooms = new List<GameObject>();
    public List<GameObject> currentlySpawnableMushrooms = new List<GameObject>();

    //parent to hold instantiated mushrooms for later cleanup
    public GameObject locationMushroomParent;
    
    

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject listMush in allLocationMushrooms)
        {
            //check if spawnable day matches current
            int dayNumber = dayofWeek.currentDay;
            int timeNumber = timeOfDay.currentTimeOfDay;
            bool dayTest = listMush.GetComponent<Mushroom>().daysList[dayNumber];
            bool timeTest = listMush.GetComponent<Mushroom>().timesList[timeNumber];
            if (dayTest && timeTest)
            {
                currentlySpawnableMushrooms.Add(listMush);
                Debug.Log("Mushroom added to spawnable!");
            }

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!mushSpawned.alreadySpawned)
        {
            pickSpawns();
            placeMushrooms();
            //mushSpawned.alreadySpawned = true;
        }
    }



    void pickSpawns()
    {
        //generate a randomized list of possible spawn locations from all
        //possible spawns that were added to that list in the inspector
        for (int j = 0; j < allPotentialSpawns.Count; j++)
        {
            int rnd = Random.Range(0, allPotentialSpawns.Count);
            GameObject temp = allPotentialSpawns[rnd];
            spawnLocations.Add(temp);
            //allPotentialSpawns.RemoveAt(rnd);
        }

    }

    void placeMushrooms()
    {
        /*
        the number of any  individual kind of mushroom added to the
        "All Location Mushrooms" list in the inspector
        is how many of that mushroom will get spawned at a time
        */
        for (int i = 0; i < currentlySpawnableMushrooms.Count; i++ )
        {
            Transform placeHere;
            placeHere = spawnLocations[i].GetComponent<Transform>();
       
            Instantiate(currentlySpawnableMushrooms[i], placeHere.position, placeHere.rotation, locationMushroomParent.transform);
            Debug.Log("Mushroom Spawned.");
            Debug.Log(i);
        }

        spawnLocations.Clear();
        currentlySpawnableMushrooms.Clear();
    }

    public void clearSpawnedMushrooms()
    {
        while (locationMushroomParent.transform.childCount > 0)
        {
            DestroyImmediate(locationMushroomParent.transform.GetChild(0).gameObject);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            clearSpawnedMushrooms();
            Debug.Log("Local Mushrooms Eradicated.");
        }
    }
}
