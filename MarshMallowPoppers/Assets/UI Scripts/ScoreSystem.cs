using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score;
    public int count;
    public int CoinAmount;
    public Text displayscore;
    public Text displaycoin;
    public GameObject ExitObject;
    public GameObject ShowMessage;
    public GameObject ShowNavPoint;
    public AudioSource DoorAppears;
    private int checknumber;

    // Use this for initialization
    void Start()
    {
        score = 0;
        ExitObject = GameObject.FindGameObjectWithTag("Exit");
        ExitObject.SetActive(false);
        ShowMessage = GameObject.FindGameObjectWithTag("Message");
        ShowMessage.SetActive(false);
        ShowNavPoint = GameObject.FindGameObjectWithTag("Navigate");
        ShowNavPoint.SetActive(false);
        checknumber = 0;
    }

    public void UpdateScore()
    {
        score = score  + 1;
        if(score > 99999)
        {
            displayscore.text = "∞";
        }
        else
        {
            displayscore.text = score.ToString();
        }
        //Debug.Log("Target Destoyed");
    }

    public void FoundCoin()
    {
        CoinAmount += 10;
        if(CoinAmount > 9999)
        {
            CoinAmount = 9999;
            displaycoin.text = CoinAmount.ToString();
        }
        else
        {
            displaycoin.text = CoinAmount.ToString();
        }
        if (CoinAmount >= count)
        {
            ExitObject.SetActive(true);
            ShowMessage.SetActive(true);
            ShowNavPoint.SetActive(true);
            if(checknumber == 0)
            {
                DoorAppears.Play();
                checknumber += 1;
            }
        }
    }

    public void FoundGrandCoin()
    {
        CoinAmount = 9999;
        displaycoin.text = "9999";
        ExitObject.SetActive(true);
        ShowMessage.SetActive(true);
        ShowNavPoint.SetActive(true);
        if (checknumber == 0)
        {
            DoorAppears.Play();
            checknumber += 1;
        }
    }
}
