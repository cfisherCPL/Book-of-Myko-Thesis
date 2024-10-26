using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreDisplay1 : MonoBehaviour
{
   private TMP_Text _scoreText;
   public ScoreTracker getScore;

   void Awake()
   {
     _scoreText = GetComponent<TMP_Text>();
   }

   void Start()
   {
     _scoreText.text = $"Mushrooms Collected: {getScore.trackedScore}";
   }

   void FixedUpdate()
   {
     _scoreText.text = $"Mushrooms Collected: {getScore.trackedScore}";
   }

   public void UpdateScore(ScoreManager scoreController)
   {
     _scoreText.text = $"Mushrooms Collected: {scoreController.score}";
   }
}

