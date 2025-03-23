using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadLetter : MonoBehaviour
{
    [SerializeField] public GameObject popupText;
    [SerializeField] public GameObject letterPanel;

    private bool canRead;
    private void Awake()
    {
        popupText.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(true);
        canRead = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(false);
        canRead = false;
    }
    void Update()
    {
        if (canRead)
        {
            if (Input.GetKeyDown("e"))
            {
                letterPanel.gameObject.SetActive(true);
            }
        }
    }
}
