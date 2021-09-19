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
    [SerializeField] Button MusicPlaylist;
    public void togglePlayButton()
    {
        playButton.gameObject.SetActive(!playButton.IsActive());
        pauseButton.gameObject.SetActive(!pauseButton.IsActive());
    }

    public void toggleFullScreen(bool fullscreen)
    {
        if (fullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            MusicPlaylist.interactable = false;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            MusicPlaylist.interactable = true;
        }
    }
    public void toggleTaskPlayButton()
    {
        taskPlayButton.gameObject.SetActive(!taskPlayButton.IsActive());
        taskPauseButton.gameObject.SetActive(!taskPauseButton.IsActive());
    }
}
