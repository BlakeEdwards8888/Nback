using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.Progression
{
    [CreateAssetMenu(fileName = "Difficulty Store")]
    public class DifficultyStore: ScriptableObject
    {
        [SerializeField] float[] timeLimits;
        //[SerializeField] Difficulty[] difficulties;

        //[System.Serializable]
        //struct Difficulty
        //{
        //    public float[] timeLimits;
        //}

        public float GetLevels()
        {
            //return difficulties[difficultyLevel].timeLimits.Length;
            return timeLimits.Length;
        }

        public float GetTimeLimit(int currentDifficulty)
        {
            //return difficulties[currentDifficulty].timeLimits[difficultyLevel];
            return timeLimits[currentDifficulty];
        }
    }
}
