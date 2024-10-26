using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPositionToSpawn;
    public VectorValue playerStorage;
    public ScoreTracker scoreToReset;
    public TimeOfDay _time;

    // Update is called once per frame
    void Update()
    {
     if (Input.anyKey && !Input.GetKey("escape"))
        {
            scoreToReset.trackedScore = 0;
            _time.currentTimeOfDay = 0;
            playerStorage.initialValue = playerPositionToSpawn;
            SceneManager.LoadScene(sceneToLoad);
        }
    
    else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
