using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options_Script : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject Pause_Menu_UI;

    void Start()
    {
        Pause_Menu_UI.SetActive(false);
    }

    void Resume()
    {
        Pause_Menu_UI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        Pause_Menu_UI.SetActive(true);
        GameIsPaused = true;
    }

    public void ResumeButton()
    {
        Resume();
    }
}
