using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keep_Object : MonoBehaviour
{
    public Toggle ToggleButton;
    /*void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }*/
    void Awake()
    {
        bool togglesound = gameObject.GetComponent<Toggle>().isOn;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Toggle");
        if (objs.Length > 1 && togglesound)
        {
            Destroy(objs[0].gameObject);
            ToggleButton.isOn = false;
        }
        DontDestroyOnLoad(objs[1].gameObject);
    }
}
