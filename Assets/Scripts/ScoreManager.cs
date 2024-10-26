using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent OnScoreChanged;
    public ScoreTracker currentScore;

    public static ScoreManager Instance {get;private set;}

    [SerializeField] public int score;
 
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

    public void IncreaseScore(int amount)
    {
        currentScore.trackedScore += amount;
        score = currentScore.trackedScore;
        OnScoreChanged.Invoke();
    }
}
