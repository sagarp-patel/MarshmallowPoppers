using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score;
    public Text displayscore;

    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    public void UpdateScore()
    {
        score = score  + 5;
        if(score > 9999999)
        {
            displayscore.text = "Score: ∞";
        }
        else
        {
            displayscore.text = "Score: " + score.ToString();
        }
        Debug.Log("Target Destoyed");
    }
}
