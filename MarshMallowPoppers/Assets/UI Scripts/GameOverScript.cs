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
    public GameObject DisableCursorAim;

    void Start()
    {
        DisableScript.GetComponent<PauseMenu>().enabled = false;
        DisablePlayer.GetComponent<Player_Controller>().enabled = false;
        DisableCursorAim.GetComponent<CursorAim>().enabled = false;
}

    public void Restart(string SceneName)
    {
        Time.timeScale = 1f;
        DisableScript.GetComponent<PauseMenu>().enabled = true;
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
        SceneManager.LoadScene(SceneName);
    }

    public void Quit(string SceneName)
    {
        Time.timeScale = 1f;
        DisableScript.GetComponent<PauseMenu>().enabled = true;
        DisablePlayer.GetComponent<Player_Controller>().enabled = true;
        SceneManager.LoadScene(SceneName);
    }
}
