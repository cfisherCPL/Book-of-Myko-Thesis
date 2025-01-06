using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private TMP_Text popupText;


    private void Awake()
    {
        popupText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Dialogue Space");

        if (other.CompareTag("Player") && other.TryGetComponent( out PlayerIsTrigger player))
        {
            player.Interactable = this;
            popupText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited Dialogue Space");

        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerIsTrigger player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
                popupText.gameObject.SetActive(false);
            }
        }
        
    }


    public void Interact(PlayerIsTrigger player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }

}
