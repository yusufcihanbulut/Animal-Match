using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening; // DOTween kütüphanesini kullan

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 30f;

    [SerializeField] TMP_Text countdownText;
    [SerializeField] RectTransform alarmClockIcon; // Çalar saat ikonunun RectTransform'u

    void Start()
    {
        currentTime = startingTime;
        StartShake(); // Çalar saati titretmeye baþla
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            EndGame();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    void StartShake()
    {        
        alarmClockIcon.DOShakeRotation(1f, strength: new Vector3(0, 0, 7), vibrato: 40, randomness: 90, fadeOut: false)
            .SetLoops(-1); 
    }
}
