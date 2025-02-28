using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton pattern used

    public static GameManager instance;
    public ItemManager itemManager;
    public UI_Manager uiManager;

    [SerializeField] public PlayerIsTrigger player;



    private void Awake()
    {
        
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        

        itemManager = GetComponent<ItemManager>();
        uiManager = GetComponent<UI_Manager>();

        //player = FindObjectOfType<PlayerIsTrigger>();
    }
}
