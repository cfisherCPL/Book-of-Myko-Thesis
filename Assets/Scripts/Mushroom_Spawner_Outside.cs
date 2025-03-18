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
    
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        pickViableMushrooms();
        pickSpawns();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!mushSpawned.alreadySpawned)
        {
            
            placeMushrooms();
            mushSpawned.alreadySpawned = true;
        }
    }

    void pickViableMushrooms()
    {
        if (!mushSpawned.alreadySpawned)
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
                    //listMush.tag = "MushroomClone";
                    currentlySpawnableMushrooms.Add(listMush);
                    Debug.Log("Mushroom added to spawnable!");
                }

            }
        }
    }

    void pickSpawns()
    {

        //generate a randomized list of possible spawn locations from all
        //possible spawns that were added to that list in the inspector
        if (!mushSpawned.alreadySpawned)
        { 
            for (int j = 0; j < allPotentialSpawns.Count; j++)
            {
                GameObject temp = allPotentialSpawns[j];
                spawnLocations.Add(temp);
                ShuffleList(spawnLocations);
            }
        }
    }

    //ShuffleList is a Fisher-Yates method
    //intended to randomize the order of items
    //in an existing list
    void ShuffleList(List <GameObject> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            GameObject temp = list[i];
            list[i] = list[j];
            list[j] = temp;
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
       
            GameObject mushClone = Instantiate(currentlySpawnableMushrooms[i], placeHere.position, placeHere.rotation, locationMushroomParent.transform);
            Debug.Log("Mushroom Spawned.");
            Debug.Log(i);
        }

        spawnLocations.Clear();
        currentlySpawnableMushrooms.Clear();
    }

    public void clearSpawnedMushrooms()
    {
        //wipe any spawned mushrooms in local area
        while (locationMushroomParent.transform.childCount > 0)
        {
            DestroyImmediate(locationMushroomParent.transform.GetChild(0).gameObject);
        }

        
        //find any stray mushrooms in the scene
        GameObject[] foundMushrooms;
        foundMushrooms = GameObject.FindGameObjectsWithTag("DroppedMushroom");

        //destroy any stray mushrooms that were found
        foreach (GameObject mushroom in foundMushrooms)
        {
            Destroy(mushroom);
        }

        //when leaving an area that clears mushrooms
        //reset and allow spawning again 2-7-25
        mushSpawned.alreadySpawned = false;
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
