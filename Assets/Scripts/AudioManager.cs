using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI clipTitle;
    [SerializeField] Track track;
    //public Text clipTime;

    private float fullLength;
    private float playTime;
    private int seconds;
    private int minutes;

    private bool isPaused = false;
    private bool random = false;
    private int currentClip = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Stop();

    }

    public void PlayMusic()
    {
        if (isPaused)
        {
            audioSource.Play();
            isPaused = false;
        }
        else if (!audioSource.isPlaying)
        {
            NextClip();
        }
    }

    private void Update()
    {
        if (!isPaused && audioSource.isPlaying)
        {
            playTime = audioSource.time;
            UpdateSlider();
            //ShowPlayTime();
        }
    }

    public void NextClip()
    {
        audioSource.Stop();
        audioSource.time = 0.0f;
        slider.value = 0.0f;
        if (random)
        {
            currentClip = (currentClip + Random.Range(1, audioClips.Count)) % audioClips.Count;
        }
        else
            currentClip = (currentClip + 1) % audioClips.Count;

        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        ShowCurrentTitle();

    }

    public void PreviousClip()
    {
        audioSource.Stop();
        audioSource.time = 0.0f;
        slider.value = 0.0f;
        if (random)
        {
            currentClip = (currentClip + Random.Range(1, audioClips.Count)) % audioClips.Count;
        }
        else
            currentClip = (currentClip + audioClips.Count - 1) % audioClips.Count;

        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        ShowCurrentTitle();
    }

    public void PauseMusic()
    {
        isPaused = true;
        audioSource.Pause();
    }

    public void MuteMusic()
    {
        audioSource.mute = !audioSource.mute;
    }

    void ShowCurrentTitle()
    {
        clipTitle.text = audioSource.clip.name;
        fullLength = (int)audioSource.clip.length;
    }

    void ShowPlayTime()
    {
        //seconds = playTime % 60;
        //minutes = (playTime / 60) % 60;
        //clipTime.text = minutes + ":" + seconds.ToString("D2") + "/"+((fullLength / 60) % 60) + ":"+(fullLength%60).ToString("D2");
    }
    public void RandomMusic(bool isRandom)
    {
        random = isRandom;
    }
    //void UpdateSlider()
    //{
    //    if (!slider.isUserControl)
    //    {
    //        slider.value = audioManager.GetPlayTime() / audioManager.GetFullLength();
    //    }

    //    if (slider.value >= slider.maxValue)
    //    {
    //        audioManager.NextClip();
    //    }
    //}
    void UpdateSlider()
    {
        //Debug.Log(track.IsUserControl());
        if(!track.IsUserControl())
        {
            slider.value = playTime / fullLength;
        }

        if (slider.value >= slider.maxValue)
        {
            NextClip();
        }
    }
    public float GetPlayTime()
    {
        return playTime;
    }
    public float GetFullLength()
    {
        return fullLength;
    }
    public void SetAudioSource(float i_sliderTime)
    {
        audioSource.time = i_sliderTime;
    }    
}
