using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Nestre.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] TMP_Text continueText, rewardText;
        [SerializeField] GameObject nextLevelButton;
        [TextArea]
        [SerializeField] string successText;
        [TextArea]
        [SerializeField] string failText;

        ShowHideUI showHideUI;

        private void Awake()
        {
            showHideUI = GetComponent<ShowHideUI>();
        }

        public void Setup(bool success, float reward)
        {
            continueText.text = success ? successText : failText;
            rewardText.text = $"You earned {reward} points";
            nextLevelButton.SetActive(success);
        }

        public void Toggle()
        {
            showHideUI.Toggle();
        }
    }
}
