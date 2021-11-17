using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Nestre.Progression;

namespace Nestre.UI
{
    public class HelpText : MonoBehaviour
    {
        [TextArea] [Tooltip("Use '$ins' to indicate an inserted value")]
        [SerializeField] string content;
        TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
            Progressor.instance.onDifficultyIncreased += () => { UpdateText((int)Progressor.instance.GetCurrentDifficulty() + 1); };
        }

        public void UpdateText(int insert)
        {
            text.text = content.Replace("$ins", insert.ToString());
        }

        private void OnDisable()
        {
            Progressor.instance.onDifficultyIncreased += () => { UpdateText((int)Progressor.instance.GetCurrentDifficulty() + 1); };
        }
    }
}
