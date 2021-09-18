using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    private int currentClip;
    [SerializeField] AudioSource audioSource;
    public Text clipTitle;
    public Text clipTime;

    private int fullLength;
    private int playTime;
    private int seconds;
    private int minutes;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        PlayMusic();
    }

    public void PlayMusic()
    {        
        if (audioSource.isPlaying)
        {
            return;
        }

        currentClip--;
        if (currentClip < 0)
        {
            currentClip = audioClips.Length - 1;
        }        
        
    }

    private void Update()
    {
        
        if (active)
        {
            if (audioSource.isPlaying)
            {
                playTime = (int)audioSource.time;
                ShowPlayTime();
            }
            else
                NextClip();
        }
    }    

    public void NextClip()
    {        
        audioSource.Stop();
        currentClip++;
        if (currentClip > audioClips.Length - 1)
        {
            currentClip = 0;
        }
        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        ShowCurrentTitle();
    }

    public void PreviousClip()
    {
        audioSource.Stop();
        currentClip--;
        if (currentClip <0)
        {
            currentClip = audioClips.Length - 1;
        }

        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        ShowCurrentTitle();
    }

    public void StopMusic()
    {
        active = false;
        audioSource.Stop();
    }

    public void MuteMusic()
    {
        audioSource.mute = !audioSource.mute;
    }

    void ShowCurrentTitle()
    {
        //clipTitle.text = audioSource.clip.name;
        fullLength = (int)audioSource.clip.length;
    }

    void ShowPlayTime()
    {
        seconds = playTime % 60;
        minutes = (playTime/60) % 60;
        //clipTime.text = minutes + ":" + seconds.ToString("D2") + "/"+((fullLength / 60) % 60) + ":"+(fullLength%60).ToString("D2");
    }
}
