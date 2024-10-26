using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MushroomTouched : MonoBehaviour
{
    public CollectableType itemType;
    public UnityEvent mushroomWasTouched;
    AudioSource soundEffect;
    Collider2D trigger;

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

   }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerIsTrigger player = collision.GetComponent<PlayerIsTrigger>();

        if (player)
        {
            soundEffect.Play();
            ScoreManager.Instance.IncreaseScore(pointsPerCollect);
            StaminaManager.Instance.DecreaseStamina(staminaCost);
            mushroomWasTouched.Invoke();
            player.inventory.Add(itemType);

            Destroy(this.gameObject, 0.1f);
        }
        
    }


}

public enum CollectableType
{
    NONE, MUSHROOM
}
