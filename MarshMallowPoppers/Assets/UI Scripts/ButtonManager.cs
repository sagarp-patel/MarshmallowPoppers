using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject DisableFirstPanel;
    public GameObject OptionsMenuUI;
    public GameObject CreditsScreen;
    public GameObject StoryPanel;

    public void NewGameButton()
    {
        StoryPanel.SetActive(true);
    }

    public void PlayGameButton(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void GoBackButton()
    {
        StoryPanel.gameObject.SetActive(false);
    }

    public void OptionsButton()
    {
        DisableFirstPanel.gameObject.SetActive(false);
        OptionsMenuUI.gameObject.SetActive(true);
    }

    public void CreditsButton()
    {
        CreditsScreen.gameObject.SetActive(true);
    }

    public void ExitCredits()
    {
        CreditsScreen.gameObject.SetActive(false);
    }

    public void ExitOptions()
    {
        DisableFirstPanel.gameObject.SetActive(true);
        OptionsMenuUI.gameObject.SetActive(false);
    }

    public void ExitGameButton()
    {
        Application.Quit();     
    }
}
