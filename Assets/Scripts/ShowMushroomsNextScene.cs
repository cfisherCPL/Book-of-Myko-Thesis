using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMushroomsNextScene : MonoBehaviour
{
    [SerializeField]GameObject mushSpawnManager;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            mushSpawnManager.SetActive(true);

        }
    }
}
