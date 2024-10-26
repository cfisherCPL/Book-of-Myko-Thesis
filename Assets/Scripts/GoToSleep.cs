using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoToSleep : MonoBehaviour
{
    [SerializeField]
    private TMP_Text sleepTextPopUp;

    private bool sleepAllowed;

    private DayTimeManager dayOfWeek;
    private StaminaManager _stamina;

    private void Awake()
    {
        dayOfWeek = FindObjectOfType<DayTimeManager>();
        _stamina = FindObjectOfType<StaminaManager>();
    }

    private void Start()
    {
        sleepTextPopUp.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (sleepAllowed && Input.GetKeyDown("n"))
        {
            dayOfWeek.nextDay();
            _stamina.ResetStamina();
        }
            
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sleepAllowed = true;
        sleepTextPopUp.gameObject.SetActive(true);

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        sleepAllowed = false;
        sleepTextPopUp.gameObject.SetActive(false);

    }



}
