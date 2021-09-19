using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button pauseButton;
    [SerializeField] Button taskPlayButton;
    [SerializeField] Button taskPauseButton;
    public void togglePlayButton()
    {
        playButton.gameObject.SetActive(!playButton.IsActive());
        pauseButton.gameObject.SetActive(!pauseButton.IsActive());
    }

    public void FullScreen()
    {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }
    public void WindowScreen()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
    public void toggleTaskPlayButton()
    {
        taskPlayButton.gameObject.SetActive(!taskPlayButton.IsActive());
        taskPauseButton.gameObject.SetActive(!taskPauseButton.IsActive());
    }
}
