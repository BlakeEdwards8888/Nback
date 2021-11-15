using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nestre.Progression;

namespace Nestre.UI
{
    public class TimerBar : MonoBehaviour
    {
        Slider barUI;
        bool isActive = false;

        void Awake()
        {
            barUI = GetComponent<Slider>();
        }

        private void Start()
        {
            ResetTimer();
            Progressor.instance.onDifficultyIncreased += ResetTimer;
        }

        // Update is called once per frame
        void Update()
        {
            if (isActive)
            {
                barUI.value -= Time.deltaTime;
                if(barUI.value <= 0)
                {
                    Progressor.instance.CheckFailState(true);
                }
            }
        }

        public void SetActiveState(bool isActive)
        {
            this.isActive = isActive;
        }

        void ResetTimer()
        {
            float timeLimit = Progressor.instance.GetTimeLimit();
            barUI.maxValue = timeLimit;
            barUI.value = timeLimit;
        }

        private void OnDisable()
        {
            Progressor.instance.onDifficultyIncreased -= ResetTimer;
        }
    }
}
