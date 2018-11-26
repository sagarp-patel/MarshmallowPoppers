using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioSource Current_Audio;
    public Text Sound_Text;
    public Slider Adjust_Volume;
    public GameObject DisableSong;
    public void Toggle_Button()
    {
        bool togglesound = gameObject.GetComponent<Toggle>().isOn;
        if (togglesound)
        {
            Current_Audio.mute = false;
            Sound_Text.GetComponentInChildren<Text>().text = "Music Enabled";
        }
        else
        {
            Current_Audio.mute = true;
            Sound_Text.GetComponentInChildren<Text>().text = "Music Disabled";
        }
    }
    public void Slider_Volume()
    {
        Current_Audio.GetComponentInChildren<AudioSource>().volume = Adjust_Volume.GetComponentInChildren<Slider>().value;
    }
}
