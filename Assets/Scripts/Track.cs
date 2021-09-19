using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] AudioManager audioManager;
    Slider slider;
    bool isUserControl = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void OnPointerDown(PointerEventData a)
    {
        isUserControl = true;
    }
    public void OnPointerUp(PointerEventData a)
    {
        audioManager.SetAudioSource(slider.value * audioManager.GetFullLength());
        isUserControl = false;
    }
    public bool IsUserControl()
    {
        return isUserControl;
    }
}
