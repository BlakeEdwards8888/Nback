using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float length;

    Image fillImage;
    TMP_Text countdownText;
    float timeRemaining;
    AudioSource audioSource;
    float timeSinceTick;

    public UnityEvent onTimerFinished;

    // Start is called before the first frame update
    void Awake()
    {
        fillImage = GetComponent<Image>();
        countdownText = GetComponentInChildren<TMP_Text>();
        timeRemaining = length;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        timeSinceTick += Time.deltaTime;

        if (timeSinceTick >= 1)
        {
            audioSource.Play();
            timeSinceTick = 0;
        }

        countdownText.SetText(Mathf.CeilToInt(timeRemaining).ToString());
        fillImage.fillAmount = timeRemaining/length;

        if (timeRemaining <= 0)
        {
            onTimerFinished?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
