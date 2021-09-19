using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TMP_InputField minutesStr;
    [SerializeField] TMP_InputField taskNameInput;
    [SerializeField] TextMeshProUGUI taskNamePaste;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip timeOutSound;
    [SerializeField] TextMeshProUGUI realTime;

    private float currentTime = 0f;
    private float startingTime = 10f;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowRealTime());
    }

    public void SetTimer()
    {
        int minutes=0;
        int.TryParse(minutesStr.text, out minutes);

        if (minutes > 999)
        {
            minutes = 999;
        }
        else if (minutes <= 0)
        {
            minutes = 1;
        }

        startingTime = minutes * 60;
        currentTime = startingTime;
        active = true;
    }

    public void ResetTimer()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = (currentTime / 60).ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
                PlayTimeOutSound();
                active = false;
            }
        }
    }

    public void PauseGame()
    {
        active = false;
    }


    public void ResumeGame()
    {
        active = true;
    }

    public void SetTask()
    {
        taskNamePaste.text = taskNameInput.text;

    }

    public void PlayTimeOutSound()
    {
        audioSource.clip = timeOutSound;
        audioSource.Play();
    }

    IEnumerator ShowRealTime()
    {
        while (true)
        {
            realTime.text = DateTime.Now.ToString("HH:mm");
            yield return new WaitForSeconds(60);
        }
    }
}
