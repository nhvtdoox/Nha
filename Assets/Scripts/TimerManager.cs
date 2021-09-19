using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TMP_InputField minutesStr;

    private float currentTime = 0f;
    private float startingTime = 10f;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
                active = false;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
