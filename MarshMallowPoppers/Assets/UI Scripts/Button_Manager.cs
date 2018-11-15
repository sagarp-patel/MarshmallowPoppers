using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_Manager : MonoBehaviour
{
    public GameObject OptionsMenuUI;

    public void NewGameButton (string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void OptionsButton()
    {
        OptionsMenuUI.gameObject.SetActive(true);
    }

    public void ExitOptions()
    {
        OptionsMenuUI.gameObject.SetActive(false);
    }

    public void ExitGameButton()
    {
        Application.Quit();     
    }
}
