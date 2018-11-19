using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject Pause_Menu_UI;
    public GameObject OptionsMenuUI;
    public GameObject DisablePlayer;
    public GameObject DisableTimerPanel;

    void Start()
    {
        //Pause_Menu_UI.SetActive(GameIsPaused);
        //Resume();
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = false;
            Pause();
        }*/
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Boolean Value: " + GameIsPaused);
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Pause_Menu_UI.SetActive(false);
        DisableTimerPanel.SetActive(true);
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
    }

    public void QuitOptions()
    {
        OptionsMenuUI.SetActive(false);
        Pause_Menu_UI.SetActive(true);
        GameIsPaused = false;
    }

    public void Pause()
    {
        Pause_Menu_UI.SetActive(true);
        DisableTimerPanel.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        DisablePlayer.GetComponent<Player_Controller>().enabled = false;
    }
    
    public void ResumeButton()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
        Resume();
    }

    public void OptionsButton()
    {
        OptionsMenuUI.SetActive(true);
        Pause_Menu_UI.SetActive(false);
    }

    public void RestartButton()
    {
        Pause_Menu_UI.SetActive(false);
        DisableTimerPanel.SetActive(true);
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("intro_scene");
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
    }

    public void MainMenuButton(string MenuScene)
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuScene);
    }
    
}
