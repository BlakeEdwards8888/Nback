using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nestre.UI;
using TMPro;

namespace Nestre.Progression
{
    public class Progressor : MonoBehaviour
    {
        public static Progressor instance;

        [SerializeField] DifficultyStore difficultyStore;
        [SerializeField] float turnsToProgress;
        [SerializeField] int maxDifficulty = 4;
        [Range(0,100)]
        [SerializeField] float successfulPercentage;
        [SerializeField] GameOverUI gameOverUI;
        [SerializeField] TimerBar timerBar;

        int currentDifficulty = 0;
        float totalTurns, correctTurns;
        float score = 0;

        public event Action onDifficultyIncreased;

        private void Awake()
        {
            instance = this;
        }

        public void CheckFailState(bool forceFail = false)
        {
            float successRate = (correctTurns / totalTurns) * 100;
            score += totalTurns > 0 ? Mathf.FloorToInt(successRate) : 0;
            bool succeeded = successRate >= successfulPercentage;

            if (currentDifficulty == maxDifficulty|| forceFail)
            {
                timerBar.SetActiveState(false);
                gameOverUI.Setup(false, score);
                gameOverUI.Toggle();
                return;
            }

            timerBar.SetActiveState(false);
            gameOverUI.Setup(succeeded, score);
            gameOverUI.Toggle();
        }

        public void IterateTurns(bool guessedCorrectly, out bool finishedLevel)
        {
            finishedLevel = false;
            totalTurns++;
            correctTurns += guessedCorrectly ? 1 : 0;

            if (totalTurns == turnsToProgress)
            {
                CheckFailState();

                //reset turns
                totalTurns = 0;
                correctTurns = 0;

                finishedLevel = true;
            }           
        }

        public void IncreaseDifficulty()
        {
            gameOverUI.Toggle();

            if (currentDifficulty <= maxDifficulty)
            {
                //progress to next level
                currentDifficulty++;

                foreach(ProgressableEntity progressableEntity in FindObjectsOfType<ProgressableEntity>())
                {
                    progressableEntity.Progress();
                }

                timerBar.SetActiveState(true);
                onDifficultyIncreased?.Invoke();
            }
        }

        public float GetLevel(string tag)
        {
            return difficultyStore.GetLevel(tag, currentDifficulty);
        }

        public int GetCurrentDifficulty()
        {
            return currentDifficulty;
        }

        public int GetMaxDifficulty()
        {
            return maxDifficulty;
        }

    }
}
