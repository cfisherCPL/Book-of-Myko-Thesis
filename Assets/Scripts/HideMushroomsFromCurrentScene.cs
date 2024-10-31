using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMushroomsFromCurrentScene : MonoBehaviour
{
    GameObject mushSpawnManager;

    private void Awake()
    {
        mushSpawnManager = GameObject.Find("Mushroom Spawn Manager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            mushSpawnManager.SetActive(false);

        }
    }
}
