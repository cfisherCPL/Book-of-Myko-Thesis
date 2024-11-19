using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private DayTimeManager timeController;
    private bool changeTime;


    void Awake()
    {
        changeTime = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currentTeleporter != null)
            {
                if (changeTime)
                {
                    DayTimeManager.Instance.nextTime();
                }
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            changeTime = currentTeleporter.GetComponent<Teleporter>().GetChangesTime();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                changeTime = false;
            }
        }
    }
}
