using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nestre.UI
{
    public class Validator : MonoBehaviour
    {
        [SerializeField] Sprite passIcon, failIcon;
        [SerializeField] AudioClip passSfx;

        Image validationImage;
        AudioSource audioSource;
        Animator anim;

        private void Awake()
        {
            validationImage = GetComponent<Image>();
            audioSource = GetComponent<AudioSource>();
            anim = GetComponent<Animator>();
        }

        public void CheckValidation(bool check)
        {
            gameObject.SetActive(true);
            anim.SetTrigger("Check");
            validationImage.sprite = check ? passIcon : failIcon;
            if (check)
                audioSource.PlayOneShot(passSfx);
        }
    }
}
