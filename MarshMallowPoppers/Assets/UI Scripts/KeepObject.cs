using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class KeepObject : MonoBehaviour
{
    public Toggle ToggleButton;
    public Slider SliderVolume;
    public AudioSource AudioObject;
    public GameObject EnableTemp;
    public float VolumePreSetting;
    public bool CheckAudio;

    void Update()
    {
        if (ToggleButton.GetComponentInChildren<Toggle>().isOn == true)
        {
            CheckAudio = true;
        }
        else if (ToggleButton.GetComponentInChildren<Toggle>().isOn == false)
        {
            CheckAudio = false;
        }
        VolumePreSetting = SliderVolume.GetComponentInChildren<Slider>().value;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("KeepObject");
        EnableTemp = GameObject.FindGameObjectWithTag("Temp");
        if (EnableTemp == null)
        {
            Destroy(ObjectList[1].gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            ToggleButton = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
            SliderVolume = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
            AudioObject = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
            SliderVolume.GetComponentInChildren<Slider>().value = VolumePreSetting;
            if (CheckAudio == true)
            {
                ToggleButton.GetComponentInChildren<Toggle>().isOn = true;
            }
            else
            {
                ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            }
            EnableTemp.SetActive(false);
        }
    }
}
