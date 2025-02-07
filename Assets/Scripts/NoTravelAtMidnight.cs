using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoTravelAtMidnight : MonoBehaviour
{
    [SerializeField]
    private TMP_Text midnightTextPopUp;


    private GameObject _collision;

    private void Awake()
    {
        midnightTextPopUp.gameObject.SetActive(false);
    }

    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        midnightTextPopUp.gameObject.SetActive(true);

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        midnightTextPopUp.gameObject.SetActive(false);

    }

}
