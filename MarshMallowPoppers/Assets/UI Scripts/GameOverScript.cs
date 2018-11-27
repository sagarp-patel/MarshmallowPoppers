using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject RestartButton;
    public GameObject QuitButton;
    public GameObject DisableScript;
    public GameObject DisablePlayer;

    void Start()
    {
        DisableScript.GetComponent<PauseMenu>().enabled = false;
        DisablePlayer.GetComponent<Player_Controller>().enabled = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        DisableScript.GetComponent<PauseMenu>().enabled = true;
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
        SceneManager.LoadScene("Intro_Scene");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        DisableScript.GetComponent<PauseMenu>().enabled = true;
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
        SceneManager.LoadScene("menu_scene");
    }
}
