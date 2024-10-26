using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StaminaManager : MonoBehaviour
{

    public UnityEvent OnStaminaChanged;
    public PlayerStamina currentStamina;

    public static StaminaManager Instance { get; private set; }

    [SerializeField]
    public int stamina;
    public int maxStamina;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseStamina(int amount)
    {
        currentStamina.stamina += amount;
        stamina = currentStamina.stamina;
        OnStaminaChanged.Invoke();

    }

    public void DecreaseStamina(int amount)
    {
        currentStamina.stamina -= amount;
        stamina = currentStamina.stamina;
        OnStaminaChanged.Invoke();
    }

    public void ResetStamina()
    {
        currentStamina.stamina = maxStamina;
    }
}
