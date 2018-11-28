using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
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
    }

    public void UpdateScore()
    {
        score = score  + 1;
        if(score > 9999999)
        {
            displayscore.text = "Score: ∞";
        }
        else
        {
            displayscore.text = "Score: " + score.ToString();
        }
        if(score == count)
        {
            ExitObject.SetActive(true);
            ShowMessage.SetActive(true);
            ShowNavPoint.SetActive(true);
        }
        //Debug.Log("Target Destoyed");
    }
    public void UpdateCoin()
    {
        CoinAmount += 10;
        displaycoin.text = CoinAmount.ToString();
    }
}
