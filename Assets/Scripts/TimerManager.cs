using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    private float currentTime=0f;
    private float startingTime=10f;
    [SerializeField] TextMeshProUGUI countdownText;
    private bool active = false;
    [SerializeField] TMP_InputField minutesStr;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    public void SetTimer()
    {
        int minutes;
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
            countdownText.text = (currentTime/60).ToString("0");
            //Debug.Log(currentTime);
            if (currentTime <= 0)
            {
                currentTime = 0;
                active = false;
            }
        }
    }
}
