using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.Progression
{
    [CreateAssetMenu(fileName = "Difficulty Store")]
    public class DifficultyStore : ScriptableObject
    {
        [SerializeField] Progressable[] progressables;

        Dictionary<string, float[]> lookupTable = null;

        public float GetLevel(string progressionTag, int difficulty)
        {
            BuildLookup();

            if (!lookupTable.ContainsKey(progressionTag))
            {
                Debug.LogWarning($"No progression data for {progressionTag}");
                return 0;
            }

            float[] levels = lookupTable[progressionTag];

            if(levels.Length == 0)
            {
                Debug.LogWarning($"Progression data for {progressionTag} contains no levels");
                return 0;
            }

            if(levels.Length < difficulty)
            {
                return levels[levels.Length - 1];
            }

            return levels[difficulty];
        }

        void BuildLookup()
        {
            if (lookupTable != null) return;

            lookupTable = new Dictionary<string, float[]>();

            foreach(Progressable progressable in progressables)
            {
                lookupTable[progressable.progressionTag] = progressable.levels;
            }
        }

        [System.Serializable]
        struct Progressable
        {
            public string progressionTag;
            public float[] levels;
        }

    }
}
