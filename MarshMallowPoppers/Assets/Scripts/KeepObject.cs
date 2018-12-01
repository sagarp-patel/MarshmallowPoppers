using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class KeepObject : MonoBehaviour
{
    public Toggle ToggleButton1;
    public Toggle ToggleButton2;
    public Slider SliderVolume1;
    public AudioSource AudioObject1;
    public GameObject EnableTemp;
    public float VolumePreSetting1;
    public bool CheckAudio1;
    public bool CheckAudio2;
    public GameObject SoundFX;

    void Update()
    {
        if (ToggleButton1.GetComponentInChildren<Toggle>().isOn == true)
        {
            CheckAudio1 = true;
        }
        else if (ToggleButton1.GetComponentInChildren<Toggle>().isOn == false)
        {
            CheckAudio1 = false;
        }

        if (ToggleButton2.GetComponentInChildren<Toggle>().isOn == true)
        {
            CheckAudio2 = true;
        }
        else if (ToggleButton2.GetComponentInChildren<Toggle>().isOn == false)
        {
            CheckAudio2 = false;
        }
        VolumePreSetting1 = SliderVolume1.GetComponentInChildren<Slider>().value;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("KeepObject");
        EnableTemp = GameObject.FindGameObjectWithTag("Temp");
        SoundFX = GameObject.FindGameObjectWithTag("SoundFX");
        if (EnableTemp == null)
        {
            Destroy(ObjectList[1].gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            ToggleButton1 = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
            SliderVolume1 = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
            AudioObject1 = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
            SliderVolume1.GetComponentInChildren<Slider>().value = VolumePreSetting1;

            ToggleButton2 = GameObject.FindGameObjectWithTag("ToggleFX").GetComponent<Toggle>();
            if (CheckAudio1 == true)
            {
                ToggleButton1.GetComponentInChildren<Toggle>().isOn = true;
            }
            else
            {
                ToggleButton1.GetComponentInChildren<Toggle>().isOn = false;
            }

            if (CheckAudio2 == true)
            {
                ToggleButton2.GetComponentInChildren<Toggle>().isOn = true;
            }
            else
            {
                ToggleButton2.GetComponentInChildren<Toggle>().isOn = false;
            }
            EnableTemp.SetActive(false);
        }
    }
}
