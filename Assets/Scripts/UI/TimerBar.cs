using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nestre.Progression;

namespace Nestre.UI
{
    public class TimerBar : MonoBehaviour, IProgressable
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
            float timeLimit = Progressor.instance.GetLevel("TimeLimit");
            barUI.maxValue = timeLimit;
            barUI.value = timeLimit;
        }

        public void Progress()
        {
            ResetTimer();
        }
    }
}
