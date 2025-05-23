using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerLightAuto : MonoBehaviour
{
    public TimeOfDay tod;

    [SerializeField] public Light2D flashlight;
    [SerializeField] public Light2D secondlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tod.currentTimeOfDay == 0 || tod.currentTimeOfDay == 1)
        {
            flashlight.gameObject.SetActive(false);
        }

        else if (tod.currentTimeOfDay == 2 || tod.currentTimeOfDay == 3 || tod.currentTimeOfDay == 4)
        {
            if (!secondlight.gameObject.activeSelf)
            {
                flashlight.gameObject.SetActive(true);
            }
            else
            {
                flashlight.gameObject.SetActive(false);
            }
        }

        /*
        if (SceneManager.GetActiveScene().name.Contains("Interior") )
        {
           flashlight.gameObject.SetActive(true); 
        }
        */
    }
}
