using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    public GameObject existingUI;
    
    // Start is called before the first frame update
    void Awake()
    {
        existingUI = GameObject.FindWithTag("PrimaryUI");
    }

    void Start()
    {
        existingUI.SetActive(false);
    }
}
