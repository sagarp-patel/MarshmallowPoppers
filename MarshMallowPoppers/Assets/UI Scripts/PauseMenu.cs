using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject DisablePlayer;
    public GameObject DisableTimerPanel;
    public GameObject DisableCursorAim;

    void Start()
    {

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
        PauseMenuUI.SetActive(false);
        DisableTimerPanel.SetActive(true);
        OptionsMenuUI.SetActive(false);
        DisableCursorAim.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
        DisableCursorAim.GetComponent<CursorAim>().enabled = true;
    }

    public void QuitOptions()
    {
        OptionsMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        DisableTimerPanel.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        DisablePlayer.GetComponent<Player_Controller>().enabled = false;
        DisableCursorAim.GetComponent<CursorAim>().enabled = false;
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
        PauseMenuUI.SetActive(false);
    }

    public void RestartButton(string SceneName)
    {
        PauseMenuUI.SetActive(false);
        DisableTimerPanel.SetActive(true);
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
        DisableCursorAim.GetComponent<CursorAim>().enabled = true;
        SceneManager.LoadScene(SceneName);
    }

    public void MainMenuButton(string MenuScene)
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuScene);
    }
    
}
