using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    private int currentClip;
    [SerializeField] AudioSource audioSource;
    public string clipTitle;
    public string clipTime;

    private int fullLength;
    private int playTime;
    private int seconds;
    private int minutes;

    // Start is called before the first frame update
    void Start()
    {
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
        StartCoroutine("WaitForMusicEnd");
    }

    IEnumerable WaitForMusicEnd()
    {
        while (audioSource.isPlaying)
        {
            playTime = (int)audioSource.time;
            ShowPlayTime();
            yield return null;
        }
        NextClip();
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
        StartCoroutine("WaitForMusicEnd");
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
        StartCoroutine("WaitForMusicEnd");
    }

    public void StopMusic()
    {
        StopCoroutine("WaitForMusicEnd");
        audioSource.Stop();
    }

    public void MuteMusic()
    {
        audioSource.mute = !audioSource.mute;
    }

    void ShowCurrentTitle()
    {
        clipTitle = audioSource.clip.name;
        fullLength = (int)audioSource.clip.length;
    }

    void ShowPlayTime()
    {
        seconds = playTime % 60;
        minutes = (playTime/60) % 60;
        clipTime = minutes + ":" + seconds.ToString("D2") + "/"+((fullLength / 60) % 60) + ":"+(fullLength%60).ToString("D2");

    }
}
