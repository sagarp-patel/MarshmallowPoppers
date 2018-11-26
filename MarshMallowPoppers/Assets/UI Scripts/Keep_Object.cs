using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.SceneManagement;
using System.IO;

public class Keep_Object : MonoBehaviour
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
        else
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
        if (scene.name == "menu_scene")
        {
            GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("KeepObject");
            if (ObjectList.Length > 1)
            {
                Destroy(ObjectList[1].gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
            EnableTemp = GameObject.FindGameObjectWithTag("Temp");
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
        if (scene.name == "Intro_Scene")
        {
            EnableTemp = GameObject.FindGameObjectWithTag("Temp");
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

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
