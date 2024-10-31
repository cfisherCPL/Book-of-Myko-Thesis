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

    GameObject mushSpawnManager;
    GameObject mushSpawnLocations;

    public GameObject[] mushroomsInScene;

    private void Awake()
    {
        mushSpawnManager = GameObject.Find("Mushroom Spawn Manager");
        mushSpawnLocations = GameObject.Find("Mushroom Spawn Locations");
        //not working. once set inactive by hidMushroomsCheck, no other method works
    }
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
                //GameObject mushList = GameObject.Find("Mushroom Spawn Manager");
                if (mushSpawnManager != null)
                {
                    //find all mushrooms in current scene by tag
                    mushroomsInScene = GameObject.FindGameObjectsWithTag("Mushroom");
                    foreach (GameObject mushToKill in mushroomsInScene)
                    {
                        Destroy(mushToKill);
                    }
                    mushSpawnTracker.alreadySpawned = false;
                    Debug.Log("cleared all mushrooms");

                }
                
            }
            
            else if (hideMushroomsCheck) //works
            {
                if (mushSpawnManager != null)
                {
                    mushroomsInScene = GameObject.FindGameObjectsWithTag("Mushroom");
                    foreach (GameObject mushToHide in mushroomsInScene)
                    {
                        float alpha = 0.0f;
                        Color color = mushToHide.GetComponent<Renderer>().material.color;
                        color.a = alpha;
                    }

                }
                /* working version
                GameObject mushList = GameObject.Find("Mushroom Spawn Manager");
                if (mushList != null)
                {
                    mushList.SetActive(false);
                    Debug.Log("hid all mushrooms");
                }
                */
            }

            else if (showMushroomsCheck) //doesnt work due to .find not working for inactive objects
            {
                if (mushSpawnManager != null)
                {
                    mushroomsInScene = GameObject.FindGameObjectsWithTag("Mushroom");
                    foreach (GameObject mushToHide in mushroomsInScene)
                    {
                        float alpha = 1.0f;
                        Color color = mushToHide.GetComponent<Renderer>().material.color;
                        color.a = alpha;
                    }
                }
                /*
                GameObject[] spawnManager = Resources.FindObjects
                GameObject mushList = GameObject.Find("Mushroom Spawn Manager");
                //GameObject spawnLocations = mushList.transform.GetChild(0).gameObject;
                if (mushList != null)
                {
                    //spawnLocations.SetActive(true);
                    Debug.Log("showed all mushrooms");
                }
                */
            }
        
            Debug.Log("Made it past the if-else group");
            playerStorage.initialValue = playerPositionToSpawn;
            //FindObjectTag<"Player"> transform.position = spawnPosition.initialValue;
            SceneManager.LoadScene(sceneToLoad);
        }
    }   
}
