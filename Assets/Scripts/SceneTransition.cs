using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPositionToSpawn;
    public VectorValue playerStorage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStorage.initialValue = playerPositionToSpawn;
            //FindObjectTag<"Player"> transform.position = spawnPosition.initialValue;
            SceneManager.LoadScene(sceneToLoad);
        }
    }   
}
