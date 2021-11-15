using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.AudioManagement
{
    public class Muter : MonoBehaviour
    {
        bool isMuted;

        private void Awake()
        {
            AudioListener.volume = isMuted ? 0 : 1;
        }

        public void ToggleMute()
        {
            isMuted = !isMuted;
            AudioListener.volume = isMuted ? 0 : 1;
        }

    }
}
