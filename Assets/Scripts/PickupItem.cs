using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PickupItem : MonoBehaviour
{
    //player enters trigger area of item
    //player pressed "pickup" button
    //item is added to player inventory
    //item is deleted from the scene

    public CollectableType itemType;
    public UnityEvent itemWasTouched;
    AudioSource soundEffect;
    Collider2D trigger;

    [SerializeField] private TMP_Text popupText;
    [SerializeField] private int pointsPerCollect;
    [SerializeField] private int staminaCost;

    private ScoreManager _scoreController;
    private StaminaManager _staminaController;

   private void Awake()
   {
        _scoreController = FindObjectOfType<ScoreManager>();
        _staminaController = FindObjectOfType<StaminaManager>();
        soundEffect = GetComponent<AudioSource>();
        trigger = GetComponent<Collider2D>();
        popupText.gameObject.SetActive(false);

   }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerIsTrigger player = collision.GetComponent<PlayerIsTrigger>();

        if (player)
        {
            popupText.gameObject.SetActive(true);
            //soundEffect.Play();
            //ScoreManager.Instance.IncreaseScore(pointsPerCollect);
            //StaminaManager.Instance.DecreaseStamina(staminaCost);
            //itemWasTouched.Invoke();
            //player.inventory.Add(itemType);

            //Destroy(this.gameObject, 0.1f);
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(false);
    }


}

public enum CollectableType
{
    NONE, INDIGO_MUSH1,
}
