using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider slider;

    public Text clipTitle;
    public Text clipTime;

    private int fullLength;
    private int playTime;
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
            playTime = (int)audioSource.time;
            UpdateSlider();
            //ShowPlayTime();
        }
    }

    public void NextClip()
    {
        audioSource.Stop();
        if (random)
        {
            currentClip = (currentClip + Random.Range(1, audioClips.Length)) % audioClips.Length;
        }
        else
            currentClip = (currentClip + 1) % audioClips.Length;

        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        //ShowCurrentTitle();

    }

    public void PreviousClip()
    {
        audioSource.Stop();
        if (random)
        {
            currentClip = (currentClip + Random.Range(1, audioClips.Length)) % audioClips.Length;
        }
        else
            currentClip = (currentClip + audioClips.Length - 1) % audioClips.Length;

        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        //ShowCurrentTitle();
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
        //clipTitle.text = audioSource.clip.name;
        fullLength = (int)audioSource.clip.length;
    }

    void ShowPlayTime()
    {
        seconds = playTime % 60;
        minutes = (playTime / 60) % 60;
        //clipTime.text = minutes + ":" + seconds.ToString("D2") + "/"+((fullLength / 60) % 60) + ":"+(fullLength%60).ToString("D2");
    }

    void UpdateSlider()
    {
        slider.value = playTime * 1.0f / fullLength;

        if (slider.value >= slider.maxValue)
        {
            audioSource.Stop();
            slider.value = slider.minValue;
        }
    }

    public void SetSilder(float i_slider)
    {
        audioSource.time = i_slider * fullLength;
    }

    public void RandomMusic()
    {
        random = !random;
    }
}
