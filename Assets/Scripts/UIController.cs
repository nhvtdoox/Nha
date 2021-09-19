using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button pauseButton;
    public void togglePlayButton()
    {
        playButton.gameObject.SetActive(!playButton.IsActive());
        pauseButton.gameObject.SetActive(!pauseButton.IsActive());
    }
}
