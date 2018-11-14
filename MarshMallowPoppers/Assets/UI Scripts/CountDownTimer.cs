using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public int currentTime = 0;
    public int startingTime = 10;
    public Text countdownText;
    public GameObject GameOver;
    public GameObject DisableUI;

    void Start()
    {
        InvokeRepeating("Count", 0.0f, 1.0f);
        currentTime = startingTime;
        GameOver.SetActive(false);
        DisableUI.SetActive(true);
    }
    void Count()
    {
        if (currentTime == 0)
        {
            //currentTime = startingTime;
            GameOver.SetActive(true);
            DisableUI.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            currentTime = currentTime - 1;
        }
        countdownText.text = currentTime.ToString();

    }
}
