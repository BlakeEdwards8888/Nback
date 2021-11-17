using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nestre.AudioManagement
{
    public class MuteMusic : MonoBehaviour
    {
        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void ToggleMusic()
        {
            audioSource.mute = !audioSource.mute;
        }
    }
}
