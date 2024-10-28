using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPositionToSpawn;
    public VectorValue playerStorage;
    
    
    public bool clearMushroomsCheck;
    public bool hideMushroomsCheck;
    public bool showMushroomsCheck;
    public AlreadySpawned mushSpawnTracker;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check to see if going back to the cabin area
        clearMushroomsCheck = sceneToLoad.Contains("Cabin");
        hideMushroomsCheck = sceneToLoad.Contains("Interior");
        showMushroomsCheck = sceneToLoad.Contains("Outside");
        
        if (collision.CompareTag("Player"))
        {
            
            if (clearMushroomsCheck) //works
            {
                GameObject mushList = GameObject.Find("Mushroom Spawn Manager");
                if (mushList != null)
                {
                    Destroy(mushList);
                    mushSpawnTracker.alreadySpawned = false;
                    Debug.Log("cleared all mushrooms");
                }
                
            }
            
            else if (hideMushroomsCheck) //works
            {
                GameObject mushList = GameObject.Find("Mushroom Spawn Manager");
                if (mushList != null)
                {
                    mushList.SetActive(false);
                    Debug.Log("hid all mushrooms");
                }
            }

            else if (showMushroomsCheck) //doesnt work due to .find not working for inactive objects
            {
                GameObject[] spawnManager = Resources.FindObjects
                GameObject mushList = GameObject.Find("Mushroom Spawn Manager");
                //GameObject spawnLocations = mushList.transform.GetChild(0).gameObject;
                if (mushList != null)
                {
                    //spawnLocations.SetActive(true);
                    Debug.Log("showed all mushrooms");
                }
                
            }

            Debug.Log("Made it past the if-else group");
            playerStorage.initialValue = playerPositionToSpawn;
            //FindObjectTag<"Player"> transform.position = spawnPosition.initialValue;
            SceneManager.LoadScene(sceneToLoad);
        }
    }   
}
