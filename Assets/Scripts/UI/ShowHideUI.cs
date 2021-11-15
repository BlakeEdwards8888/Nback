using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.UI
{
    public class ShowHideUI : MonoBehaviour
    {
        [SerializeField] GameObject uiContainer;

        public void Toggle()
        {
            uiContainer.SetActive(!uiContainer.activeSelf);
        }
    }
}
