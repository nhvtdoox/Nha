using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private float currentTime=0f;
    private float startingTime=10f;
    [SerializeField] Text countdownText;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    public void SetTimer(float minutes)
    {
        startingTime = minutes * 60;
        currentTime = startingTime;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = (currentTime/60).ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                active = false;
            }
        }
    }
}
