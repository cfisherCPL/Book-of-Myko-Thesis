using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private TMP_Text popupText;
    [SerializeField] public bool changesTime;

    public Transform GetDestination()
    {
        return destination;
    }

    public bool GetChangesTime()
    {
        return changesTime;
    }

    private void Awake()
    {
        popupText.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(false);
    }
}
