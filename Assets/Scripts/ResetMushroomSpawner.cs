using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMushroomSpawner : MonoBehaviour
{
    //this script resets the mushSpawned scriptable object
    //attach script to the Scene Transition trigger box

    public AlreadySpawned mushSpawned;
    GameObject mushSpawnManager;

    private void Awake()
    {
        mushSpawnManager = GameObject.Find("Mushroom Spawn Manager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //mushSpawned.alreadySpawned = true;
            Destroy(mushSpawnManager);
        }
    }
}
