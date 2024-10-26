using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {

        bool pauseButtonPressed = Input.GetButtonDown("Pause");

        if (pauseButtonPressed && !pauseMenu.activeSelf)
        {
            Pause();
        }
        else if (pauseButtonPressed && pauseMenu.activeSelf)
        {
            Resume();
        }
    }
}
