using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonListener : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }


    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {

        bool pausePressed = Input.GetButtonDown("Pause");

        if (pausePressed && !pauseMenu.activeSelf)
        {
            Pause();
        }
        else if (pausePressed && pauseMenu.activeSelf)
        {
            Resume();
        }
    }
}
